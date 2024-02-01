using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound_ManagerMario : MonoBehaviour
{
    public static Sound_ManagerMario instance;
    public AudioSource MusicSource;
    public bool Play_Sound = true;


    [SerializeField] List<SoundMario> Sound = new List<SoundMario>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {

        foreach (SoundMario item in Sound)
        {
            AudioSource aud = gameObject.AddComponent<AudioSource>();
            aud.loop = false;
            aud.playOnAwake = false;
            aud.clip = item.Clip;
            item.audioSource = aud;
        }
    }

    public void Play(int value)
    {
        if (UI_Manager.instance.Can_Sound == 1)
        {
            Sound[value].audioSource.volume = Sound[value].Volume;
            Sound[value].audioSource.PlayOneShot(Sound[value].Clip);
        }
    }
    public void PlayRandom(int value)
    {
        if (UI_Manager.instance.Can_Sound == 1)
        {
            int vlauePlay = Random.Range(0, Sound[value].Clips.Length);
            Sound[value].audioSource.volume = Sound[value].Volume;
            Sound[value].audioSource.clip = Sound[value].Clips[vlauePlay];
            Sound[value].audioSource.PlayOneShot(Sound[value].Clips[vlauePlay]);
        }
    }


}
