using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    [SerializeField] TextMeshProUGUI LevelText;

    // Sound 
    Sound_ManagerMario sound_Manager;
    // Setting buttons
    [SerializeField] Image[] ButtonSetting;
    [SerializeField] Sprite[] vibrSp, soundSp;
    [HideInInspector] public int CanVib_Effect, Can_Sound = 1;

    // Splash Screen
    public GameObject SplashScreen;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        sound_Manager = Sound_ManagerMario.instance;
        Can_Sound = SetIntFromPlayerPrefs("SoundKey") == 0 ? 1 : 0;
        CanVib_Effect = SetIntFromPlayerPrefs("VibrKey") == 0 ? 1 : 0;
        SoundButton();
        VibrSound();
    }

    public void Settext()
    {
        LevelText.text = "LEVEL " + GameManager.instance.FakeLevel;

    }
    public void reloadScnce()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(4);

        GameManager.instance.level += 1;
        GameManager.instance.FakeLevel += 1;


        try
        {

            if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCountInBuildSettings - 1)
            {
                GameManager.instance.level = 1;
                SceneManager.LoadScene(GameManager.instance.level);

            }
            else
            {

                SceneManager.LoadScene(GameManager.instance.level);
            }
        }
        catch (System.Exception)
        {
            GameManager.instance.level = 1;
            SceneManager.LoadScene(GameManager.instance.level);
        }

        PlayerPrefs.SetInt("Level", GameManager.instance.level);
        PlayerPrefs.SetInt("FakeLevel", GameManager.instance.FakeLevel);
        LevelText.text = "LEVEL " + GameManager.instance.FakeLevel;
        sound_Manager.Play(0);
        GameManager.instance.is_Player_Death = false;
    }

    public void PlaySound(int index)
    {
        sound_Manager.Play(index);
    }

    // setting button
    public void SoundButton()
    {
        if (Can_Sound == 1)
        {
            Can_Sound = 0;
            Sound_ManagerMario.instance.MusicSource.gameObject.SetActive(false);
        }
        else
        {
            Can_Sound = 1;
            Sound_ManagerMario.instance.MusicSource.gameObject.SetActive(true);
        }
        ButtonSetting[0].sprite = soundSp[Can_Sound];

        PlayerPrefs.SetInt("SoundKey", Can_Sound);
    }

    public void VibrSound()
    {
        if (CanVib_Effect == 1)
        {
            CanVib_Effect = 0;
        }
        else
        {
            CanVib_Effect = 1;
        }
        ButtonSetting[1].sprite = vibrSp[CanVib_Effect];
        PlayerPrefs.SetInt("VibrKey", CanVib_Effect);
    }

    int SetIntFromPlayerPrefs(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);

        }
        return 1;
    }


}
