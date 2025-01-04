using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Transform next;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy")
        {
            if (next != null)
            {
                if (other.GetComponentInParent<EnemyPanzer>())
                {
                    other.GetComponentInParent<EnemyPanzer>().OnTarget(next);
                }
                if (other.GetComponentInParent<Mashin>())
                {
                    other.GetComponentInParent<Mashin>().OnTarget(next);
                }
            }
            else 
            {
                Destroy(other.gameObject);
            }  
        }
    }
}
