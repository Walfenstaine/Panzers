using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyPanzer : MonoBehaviour
{
    public Transform target;
    public ParticleSystem gun;
    public NavMeshAgent agent;
    public float speed;
    public Rigidbody rb;
    public MeshRenderer render;
    public Vector3 muve;
    public Transform bodey, bash;
    public static Motor_Tank regit;
    float run = 0;
    float timer = 0;

    private void Awake()
    {
        agent.avoidancePriority = Random.Range(0,99);
    }
    void Shut() 
    {
        RaycastHit hit;
        Ray ray = new Ray(gun.transform.position, gun.transform.forward);
        if (Physics.Raycast(ray, out hit, 50))
        {
            if (hit.collider.tag == "Player")
            {
                Motor_Tank.regit.Damage(Random.Range(5,15));
            }
        }
        gun.Play();
    }

    public void OnTarget(Transform t) 
    {
        target = t;
    }

    void FixedUpdate()
    {
        agent.destination = target.position;
        if (Vector3.Distance(transform.position, Motor_Tank.regit.transform.position) <= 10) 
        {
            Vector3 nap = transform.position - Motor_Tank.regit.transform.position;
            bash.rotation = Quaternion.Lerp(bash.rotation, Quaternion.LookRotation(nap), 5 * Time.deltaTime);
            if (timer < 2)
            {
                timer += Time.deltaTime;
            }
            else 
            {
                timer = 0;
                Shut();
            }
        }
        muve = agent.desiredVelocity;
        if (muve != Vector3.zero)
        {
            rb.AddForce(bodey.forward * speed);
            bodey.rotation = Quaternion.Lerp(bodey.rotation, Quaternion.LookRotation(muve), 5 * Time.deltaTime);
            run += speed * Time.deltaTime;
            render.material.mainTextureOffset = new Vector2(run, 0);
        }
    }
}
