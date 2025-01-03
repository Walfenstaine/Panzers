using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class Input_Controller : MonoBehaviour
{
    public GameObject joystyk;
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

    public void Shut() 
    {
        Gun.regit.Shut();
    }
    public void Shuting() 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50))
        {
            if (hit.collider.tag == "Enemy")
            {
                Gun.regit.target = hit.collider.transform;
            }
            else
            {
                Gun.regit.Shut();
            }
        }
    }
    void Update()
    {
        
        if (YandexGame.EnvironmentData.isDesktop) 
        {
            Motor_Tank.regit.muve = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shuting();
            }
        }
    }
}
