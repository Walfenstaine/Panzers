using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip clip;
    public void Play()
    {
        SoundPlayer.regit.Play(clip);
    }
}
