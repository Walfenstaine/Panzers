using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Player_Muwer : MonoBehaviour
{
    public ParticleSystem ps;
    public Color norm, invise;
    public SpriteRenderer[] img;
    public AudioClip atac, krugAtac, dammag, ded, step, nokaute;
    public List<Kitti> kitis;
    public float speed, helse;
    public Vector3 muwe;
    public Transform bodey, cam;
    public Rigidbody rb;
    public Image helser;
    public Animator anim, damag;
    float timer = 0;
    float invis = 0;
    bool invii;
    public static Player_Muwer rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }
    public void Invise() 
    {
        for (int i = 0; i < img.Length; i++)
        {
            img[i].color = invise;
            invis = Time.time + 10;
            invii = true;
            gameObject.tag = "Invise";
        }
    }
    public void Damag()
    {
        if (helse > 20)
        {
            SoundPlayer.regit.Play(dammag);
            helse -= Random.Range(12,20);
            helser.fillAmount = helse / 100;
            damag.SetTrigger("Damag");
        }
        else
        {
            SoundPlayer.regit.Play(ded);
            Interface.rid.Sum(2, true, 0);
        }
    }
    public void Kik() 
    {
        ps.Play();
        Sword.rid.atak = 50;
        if (Sword.rid.svordHelse >= 25)
        {

            if (timer < Time.time)
            {
                SoundPlayer.regit.Play(atac);
                timer = Time.time + 0.7f;
                anim.SetTrigger("Kik");
                invis = 0;

            }

        }
        else 
        {
            G_I.rid.Katana();
            if (timer < Time.time)
            {
                timer = Time.time + 0.7f;
                SoundPlayer.regit.Play(nokaute);
            }
                
        }
        
    }
    public void Kik2() 
    {
        ps.Play();
        Sword.rid.atak = 100;
        if (timer < Time.time) 
        {
            if (Sword.rid.svordHelse >= 50)
            {
                timer = Time.time + 0.7f;
                SoundPlayer.regit.Play(krugAtac);
                anim.SetTrigger("Kik2");
                invis = 0;

            }
            else
            {
                G_I.rid.Katana();
                if (timer < Time.time)
                {
                    timer = Time.time + 0.7f;
                    SoundPlayer.regit.Play(nokaute);
                }
            }
        }
            
    }
    public void AddKitti(Kitti kitti) 
    {
        kitis.Add(kitti);
        kitis[0].target = transform;
        for (int i = 1; i < kitis.Count; i++)
        {
            kitis[i].target = kitis[i - 1].transform;
        }
    }
    public void Step()
    {
        SoundPlayer.regit.Play(step);
    }
    private void FixedUpdate()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + rb.velocity, Time.deltaTime);
        if (helse < 100)
        {
            helse += 0.3f * Time.deltaTime;
        }
        else 
        {
            helse = 100;
        }
        if (invii) 
        {
            if (Time.time > invis) 
            {
                for (int i = 0; i < img.Length; i++)
                {
                    gameObject.tag = "Player";
                    img[i].color = norm;
                    invii = false;
                }
            }
        }
        if (muwe != Vector3.zero)
        {
            anim.SetFloat("Speed", rb.velocity.magnitude/4);
            bodey.rotation = Quaternion.Lerp(bodey.rotation, Quaternion.LookRotation(muwe),speed * Time.deltaTime);
            rb.AddForce(transform.forward * speed);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if (kitis.Count > 0) 
        {
            for (int i = 0; i < kitis.Count; i++)
            {
                if (kitis[i] == null)
                {
                    kitis.RemoveAt(i);
                }
            }
        }
    }
}
