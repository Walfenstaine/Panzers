using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using YG;
public class Enemy : MonoBehaviour
{
    public FOVArea fov;
    public AudioClip dedd, step;
    public Transform target, point;
    public GameObject[] loot;
    public NavMeshAgent agent;
    public Image helser;
    public Animator  ded, domag;
    public float speed, helse;
    bool aliv = true;

    private void Awake()
    {
        agent.avoidancePriority = Random.Range(40,50);
    }
    public void Damag(int damag) 
    {
        target = Player_Muwer.rid.transform;
        if (helse > damag)
        {
            domag.SetTrigger("Damag");
            helse -= damag;
            helser.fillAmount = helse / 100;
        }
        else 
        {
            if (aliv)
            {
                int index = Random.Range(0, 5);
                Instantiate(loot[index], transform.position, Quaternion.identity);
                Interface.rid.SaveGame();
                ded.SetTrigger("Dead");
                SoundPlayer.regit.Play(dedd);
                Destroy(gameObject,1);
                aliv = false;
            }
        }
    }
    public void Ontarget() 
    {
        target = Player_Muwer.rid.transform;
    }
    public void Invisee()
    {
        fov.active = false;
        target = null;
    }
    public void Visible()
    {
        fov.active = true;
    }
    public void OnPoint(Transform t)
    {
        
        point = t;
    }
    public void Step()
    {
        if (Vector3.Distance(transform.position, Player_Muwer.rid.transform.position) < 8) 
        {
            SoundPlayer.regit.Play(step);
        }
       
    }
    private void FixedUpdate()
    {
        ded.SetFloat("Speed", agent.velocity.magnitude/agent.speed);
        if (agent.enabled)
        {
            if (target != null)
            {
                agent.destination = target.position;
            }
            else
            {
                if (point != null)
                {
                    agent.destination = point.position;
                }
            }
        }
        else 
        {
            agent.enabled = true;
        }
    }
}
