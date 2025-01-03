using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerodrome : MonoBehaviour
{
    public GameObject helli;
    public Transform bodey;
    public float interval;
    public Animator anim;
    float timer = 0;

    public void Emit() 
    {
        Instantiate(helli, bodey.position, bodey.rotation);
    }
    private void FixedUpdate()
    {
        if (Time.time > timer) 
        {
            timer = Time.time + interval;
            anim.SetTrigger("Start");
        }
    }
}
