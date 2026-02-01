using UnityEngine;

[System.Serializable]
public class SoundData
{
    public string name;
    public AudioClip clip;
    
    [Range(0f, 1f)]
    public float volume = 0.5f;
    public bool loop;
    
    [HideInInspector]
    public AudioSource source;
}
