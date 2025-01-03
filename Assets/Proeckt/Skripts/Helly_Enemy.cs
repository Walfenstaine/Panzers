using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Helly_Enemy : MonoBehaviour
{
    public Helly_Gun gun;
    public NavMeshAgent agent;
    float timer = 3;
    private void FixedUpdate()
    {
        agent.destination = Motor_Tank.regit.transform.position;
        if (Vector3.Distance(transform.position, Motor_Tank.regit.transform.position) <= 10)
        {
            if (Time.time > timer)
            {
                gun.Shut();
                timer = Time.time + 3;
            }
        }
    }
}
