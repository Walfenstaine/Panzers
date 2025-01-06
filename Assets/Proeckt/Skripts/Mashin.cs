using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Mashin : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public float speed;
    public Rigidbody rb;
    public Vector3 muve;
    public Transform bodey;

    public void OnTarget(Transform t)
    {
        target = t;
    }
    void FixedUpdate()
    {
        if (bodey == null)
        {
            Destroy(gameObject);
        }
        agent.enabled = true;
        agent.destination = target.position;
        muve = agent.desiredVelocity;
        if (muve != Vector3.zero)
        {
            rb.AddForce(bodey.forward * speed);
            if (bodey != null)
            {
                bodey.rotation = Quaternion.Lerp(bodey.rotation, Quaternion.LookRotation(muve), Time.deltaTime);
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }
}
