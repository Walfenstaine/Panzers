using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject enviroment;
    public float speed = 5;

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.position -= transform.up * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        float d = Vector3.Distance(Motor_Tank.regit.transform.position, transform.position);
        if (d < 3) 
        {
            Motor_Tank.regit.Damage((3 - d)*30);
        }
        Instantiate(enviroment, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
