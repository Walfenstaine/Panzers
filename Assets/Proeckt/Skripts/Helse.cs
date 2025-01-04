using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Helse : MonoBehaviour
{
    public Transform bodey;
    public ParticleSystem ps;
    public GameObject enviroment;
    public float helse;

    void OnMouseDown()

    {

        Gun.regit.target = transform;

    }
    public void Damage(float d) 
    {
        if (d < helse)
        {
            ps.Play();
            helse -= d;
        }
        else 
        {
            Instantiate(enviroment, transform.position, Quaternion.identity);
            Destroy(bodey.gameObject);
        }
    }
}
