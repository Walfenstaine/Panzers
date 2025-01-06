using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerodrome : MonoBehaviour
{
    public GameObject hely;
    public GameObject helli;
    public Transform bodey;
    public float interval;
    public Animator anim;
    bool active;
    public void Emit() 
    {
        active = false;
        hely = Instantiate(helli);
        hely.transform.position = bodey.position;
        hely.transform.rotation = bodey.rotation;
    }
    private void FixedUpdate()
    {
        if (!active) 
        {
            if (hely == null)
            {
                anim.SetTrigger("Start");
                active = true;
            }
        }
       
       
    }
}
