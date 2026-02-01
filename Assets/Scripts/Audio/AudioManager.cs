using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundData[] sounds;
    public static AudioManager instance;
    
    void Awake() {
        if (instance == null) 
        {
            instance = this;
        } 
        else 
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
        foreach (SoundData s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void Play(string songName) 
    {
        SoundData s = Array.Find(sounds, sound => sound.name == songName);
        if (s == null) 
        {
            Debug.LogWarning("Sound: " + songName + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string songName)
    {
        SoundData s = Array.Find(sounds, sound => sound.name == songName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + songName + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void MuteSound()
    {
        foreach (SoundData s in sounds) 
        {
            s.source.mute = !s.source.mute;
        }
    }
}