using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioClip bum;
    public int ammo = 30;
    public int max_Ammo = 30;
    public float relod, relodTime;
    public Transform target, gunder;
    public ParticleSystem gun;
    public static Gun regit;

    Vector3 nap = Vector3.zero;
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

    public void Shut() 
    {
        if (ammo > 0)
        {
           
            if (relod <= 0.1f)
            {
                SoundPlayer.regit.Play(bum);
                ammo -= 1;
                RaycastHit hit;
                Ray ray = new Ray(gun.transform.position, gun.transform.forward);
                if (Physics.Raycast(ray, out hit, 50))
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        hit.collider.GetComponentInParent<Helse>().Damage(8);
                    }
                }
                gun.Play();
                relod = relodTime;
            }
        }
        else 
        {
            Interface.rid.Sum(3, true, 0);
        }
    }
    private void FixedUpdate()
    {
        if (relod > 0)
        {
            relod -= Time.deltaTime;
        }
        else 
        {
            relod = 0;
        }
        if (target != null)
        {
            nap = transform.position - target.position;
            Targeting.regit.target = target;
        }
        else 
        {
            Targeting.regit.target = transform.parent;
            nap = -transform.forward;
        }
        Targeting.regit.tr = Quaternion.Angle(gunder.rotation, Quaternion.LookRotation(nap))/5;

        gunder.rotation = Quaternion.Lerp(gunder.rotation, Quaternion.LookRotation(nap), 10 * Time.deltaTime);
    }
}
