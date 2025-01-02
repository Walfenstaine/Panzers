using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor_Tank : MonoBehaviour
{
    public ParticleSystem ps;
    public Transform cam;
    public float speed, helse;
    public Rigidbody rb;
    public MeshRenderer render;
    public Vector3 muve;
    public Transform bodey;
    public static Motor_Tank regit;
    float run = 0;
    void Awake()
    {
        if (regit == null)
        {
            regit = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        regit = null;
    }
    public void Damage(float d) 
    {
        ps.Play();
        cam.GetComponent<Animator>().SetTrigger("Kik");


        if (d < helse)
        {
            helse -= d;
        }
        else 
        { 
            Interface.rid.Sum(2, true, 0); 
        }
    }

    void FixedUpdate() 
    {
        cam.position = Vector3.Lerp(cam.position, transform.position+muve, speed * Time.deltaTime);
        if (muve != Vector3.zero) 
        {
            rb.AddForce(bodey.forward * speed);
            bodey.rotation = Quaternion.Lerp(bodey.rotation, Quaternion.LookRotation(muve), 5 * Time.deltaTime);
            run += speed * Time.deltaTime;
            render.material.mainTextureOffset = new Vector2(run, 0);
            
        }
       
        
    }
}
