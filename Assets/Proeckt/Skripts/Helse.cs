using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helse : MonoBehaviour
{
    public Transform bodey;
    public ParticleSystem ps;
    public GameObject enviroment;
    public float helse;

    public void Damage(float d) 
    {
        if (d < helse)
        {
            ps.Play();
            helse -= d;
        }
        else 
        {
            Instantiate(enviroment, bodey.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
