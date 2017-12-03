using UnityEngine;
using System;

/// <summary>
/// AudioManager can be called from anywhere and the different functions are:
///     Start ( name )
///     Stop ( name )
///     SetPitch ( name, amount )
///     SetVolume ( name, amount )
///     GetSoundData ( name )
/// 
/// Name is the special name for each sound effect. Eg. Start ( "Punch" );
/// GetSoundData can be used to read all the public variables of a sound element
/// The feedback is for the sounds played when flipping tile lines
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Sound[] sounds;

    int currentHorizontalTone = 0, currentVerticalTone = 0;

    private int CurrentHorizontalTone
    {
        get { return currentHorizontalTone; }
        set
        {
            currentHorizontalTone = value;

            if (currentHorizontalTone >= 3)
                currentHorizontalTone = 0;
        }
    }

    private int CurrentVerticalTone
    {
        get { return currentVerticalTone; }
        set
        {
            currentVerticalTone = value;

            if (currentVerticalTone >= 3)
                currentVerticalTone = 0;
        }
    }

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.playOnAwake = s.onAwake;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.bypassEffects = s.bypassAll;
            s.source.bypassListenerEffects = s.bypassAll;
            s.source.bypassReverbZones = s.bypassAll;

            s.source.ignoreListenerPause = s.bypassAll;
            s.source.outputAudioMixerGroup = s.mixerGroup;

            if (s.onAwake)
                s.source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null) s.source.Stop();
        else Debug.Log("Sound \"" + name + "\" is not valid");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null) s.source.Play();
        else Debug.Log("Sound '" + name + "' is not valid");
    }

    public void SetPitch(string name, float pitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null) s.source.pitch = pitch;
        else Debug.Log("Sound '" + name + "' is not valid");
    }

    public Sound GetSoundData(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null) return s;
        else
        {
            Debug.Log("Sound '" + name + "' is not valid");
            return null;
        }
    }
}