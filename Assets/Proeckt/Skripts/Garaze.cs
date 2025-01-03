using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garaze : MonoBehaviour
{
    public float interval;
    public GameObject instatiater;
    public Transform emiter, antena, target;
    public Animator anim;
    float timer = 0;
    bool open = false;

    public void Emit() 
    {
        GameObject g = Instantiate(instatiater);
        g.transform.position = emiter.position;
        g.transform.rotation = emiter.rotation;
        g.GetComponent<EnemyPanzer>().OnTarget(target);
        target = target.GetComponent<Point>().next;
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
