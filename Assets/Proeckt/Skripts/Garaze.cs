using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garaze : MonoBehaviour
{
    public int maxCount;
    public List<GameObject> panzers;
    public float interval;
    public GameObject instatiater;
    public Transform emiter, antena, target;
    public Animator anim;
    float timer = 0;
    bool open = false;

    public void Emit() 
    {
        GameObject g = Instantiate(instatiater);
        panzers.Add(g);
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
        for (int i = 0; i < panzers.Count; i++)
        {
            if (panzers[i] == null)
            {
                panzers.RemoveAt(i);
            }
        }
        antena.Rotate(transform.up * 3);
        if (Time.time > timer) 
        {
            if (panzers.Count < maxCount) 
            {
                OnOpen();
            }
           
            timer = Time.time + interval;
        }
    }
}
