using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using YG;
public class Helse : MonoBehaviour
{
    public bool bilding;
    public Transform bodey;
    public ParticleSystem ps;
    public GameObject enviroment;
    public float helse;

    private void Start()
    {
        if (bilding) 
        {
            Interface.rid.bilds += 1;
        }
        
    }
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
            if (bilding)
            {
                if (Interface.rid.bilds > 1)
                {
                    Interface.rid.bilds -= 1;
                }
                else 
                {
                    Interface.rid.Sum(4, true, 0);
                }
            }
            Instantiate(enviroment, transform.position, Quaternion.identity);
            YandexGame.savesData.record += 1;
            Interface.rid.SaveGame();
            Destroy(bodey.gameObject);
        }
    }
}
