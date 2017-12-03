using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// A Sound class for each SFX in the game. Pitch and volume can be set through functions from AudioManager
/// </summary>
[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0.1f, 3f)]
    public float pitch = 1f;

    [Range(0f, 1.5f)]
    public float volume = 1f;

    public bool loop = false;
    public bool onAwake = false;
    public bool bypassAll = true;

    [HideInInspector]
    public AudioSource source;

    public AudioMixerGroup mixerGroup;
}