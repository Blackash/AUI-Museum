using System;
using UnityEngine;

public class DialogueSoundManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.audioMixer;
        }
    }

    public void Play(string n)
    {
        
        Sound s = Array.Find(sounds, sound => sound.name == n);
        Debug.Log("Starting audio " + s.name);
        s.source.Play();
    }

    public void Stop(string n)
    {
        Sound s = Array.Find(sounds, sound => sound.name == n);
        s.source.Stop();
    }

    public void Mute(string n)
    {
        Sound s = Array.Find(sounds, sound => sound.name == n);
        s.source.mute = true;
    }

    public void Unmute(string n)
    {
        Sound s = Array.Find(sounds, sound => sound.name == n);
        s.source.mute = false;
    }
}




    
