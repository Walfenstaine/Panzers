using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Kitti : MonoBehaviour
{
    public AudioClip clip;
    public NavMeshAgent agent;
    public Animator anim;
    public Transform target;

    private void Awake()
    {
        SoundPlayer.regit.Play(clip);
        Player_Muwer.rid.AddKitti(this);
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            anim.SetFloat("Speed", agent.velocity.magnitude/2);
            if (agent.velocity.magnitude > 0.5f)
            {
                anim.SetBool("Run", true);
            }
            else 
            {
                anim.SetBool("Run", false);
            }
            agent.destination = target.position;
        }
    }
}
