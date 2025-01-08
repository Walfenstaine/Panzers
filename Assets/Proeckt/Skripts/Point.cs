using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isLooter = false;
    public GameObject klet;
    public Transform next;
    public GameObject kitty;
    public ParticleSystem ps;
    public void Remaine() 
    {
        if (kitty != null)
        {
            if (isLooter)
            {
                int i = Random.Range(0,4);
                if (i == 2)
                {
                    Instantiate(kitty, transform.position, Quaternion.identity);
                }
            }
            else 
            {
                Instantiate(kitty, transform.position, Quaternion.identity);
            }
            
           
        }
        else{
            GetComponent<BoxCollider>().enabled = false;
        }
        klet.SetActive(false);
        ps.Play();
    }
    public void Reload() 
    {
        klet.SetActive(true);
        gameObject.tag = "Kitty";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<Enemy>().point == transform) 
            {
                other.GetComponent<Enemy>().OnPoint(next);
            }
           
        }
    }
}
