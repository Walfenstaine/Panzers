using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource sorse;
    public static SoundPlayer regit { get; set; }
    private float tim;

    void Awake()

    {
        if (regit == null)
        {
            regit = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void OnDestroy()

    {
        regit = null;
    }

    public void Play(AudioClip clip)

    {
        sorse.PlayOneShot(clip);
        if (Time.time > tim) 
        {
            
            tim = Time.time + 0.01f;
        }
        
    }

}
