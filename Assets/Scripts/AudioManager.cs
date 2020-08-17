using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    bool muted = false;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.time = s.startTime;
        }
    }

    void Start()
    {
        Play("Game Music");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound not found");
            return;
        }

        if(!s.BGM)
        {
            s.source.Play();
        }
        s.source.Play();
        s.source.SetScheduledEndTime(AudioSettings.dspTime + (s.endTime - s.startTime));
    }

    public void Mute()
    {
        muted = !muted;
        foreach (Sound s in sounds)
        {
            s.source.mute = muted;
        }
    }

}
