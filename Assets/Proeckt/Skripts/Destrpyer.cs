using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destrpyer : MonoBehaviour
{
    public AudioClip bum;
    public float limit = 1;

    private void Awake()
    {
        SoundPlayer.regit.Play(bum);
        Destroy(gameObject, limit);
    }
}
