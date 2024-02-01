using UnityEngine;
[System.Serializable]
public class SoundMario
{

    public string Name;
    [Range(0,1)]public float Volume;
    [HideInInspector] public AudioSource audioSource;
    public AudioClip Clip;
    public AudioClip[] Clips;
 
}
