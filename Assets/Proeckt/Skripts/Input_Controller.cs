using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class Input_Controller : MonoBehaviour
{
    public GameObject joystyk;
    Vector2 p;
    private void Start()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            joystyk.SetActive(false);
        }
    }
    public void Muwe(Vector2 m) 
    {
        Motor_Tank.regit.muve = new Vector3(m.x, 0, m.y);
    }

    public void Shuting() 
    {
        Gun.regit.Shut();
    }
    void Update()
    {
        
        if (YandexGame.EnvironmentData.isDesktop) 
        {
            Motor_Tank.regit.muve = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}
