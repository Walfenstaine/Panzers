using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public Animator anim;
    bool damag = false;

    private void FixedUpdate()
    {
        if (damag)
        {
            anim.SetTrigger("Kik");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            damag = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            damag = false;
        }
    }
}
