using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePoolable : IPoolable
{
    AudioSource component;

    public AudioSourcePoolable(AudioSource component)
    {
        this.component = component;
    }

    public Component GetComponent()
    {
        return component;
    }

    public bool IsAvailable()
    {
        return !component.isPlaying;
    }
}
