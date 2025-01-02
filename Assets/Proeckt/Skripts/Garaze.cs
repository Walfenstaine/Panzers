using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garaze : MonoBehaviour
{
    public float interval;
    public GameObject instatiater;
    public Transform emiter, antena;
    public Animator anim;
    float timer = 0;
    bool open = false;

    public void Emit() 
    {
        Instantiate(instatiater, emiter.position, emiter.rotation);
    }
    public void OnOpen() 
    {
        if (open)
        {
            open = false;
            anim.SetBool("Open", false);
        }
        else 
        {
            open = true;
            anim.SetBool("Open", true);
        }
    }

    private void FixedUpdate()
    {
        antena.Rotate(transform.up * 3);
        if (Time.time > timer) 
        {
            OnOpen();
            timer = Time.time + interval;
        }
    }
}
