using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
    public AudioClip sound;
    public string name;
    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}
