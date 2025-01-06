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
                    if (other.GetComponentInParent<EnemyPanzer>().target == transform) 
                    {
                        other.GetComponentInParent<EnemyPanzer>().OnTarget(next);
                    }
                    
                }
                if (other.GetComponentInParent<Mashin>())
                {
                    if (other.GetComponentInParent<Mashin>().target == transform) 
                    {
                        other.GetComponentInParent<Mashin>().OnTarget(next);
                    }
                        
                }
            }
            else 
            {
                Destroy(other.gameObject);
            }  
        }
    }
}
