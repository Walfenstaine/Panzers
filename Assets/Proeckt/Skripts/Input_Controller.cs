using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Controller : MonoBehaviour
{
    void Update()
    {
        Motor_Tank.regit.muve = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
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
    }
}
