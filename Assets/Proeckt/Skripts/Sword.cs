using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform ps;
    public AudioClip breake, wall;
    public float svordHelse = 100;
    public float atak;

    float timer = 0;
    public static Sword rid { get; set; }
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

    private void OnTriggerEnter(Collider other)
    {
        if (timer < Time.time)
        {
            if (other.tag == "Enemy")
            {
                Vector3 v = new Vector3(other.transform.position.x, Player_Muwer.rid.transform.position.y, other.transform.position.z);
                Player_Muwer.rid.transform.LookAt(v);
                other.GetComponent<Enemy>().Damag((int)atak);
                svordHelse -= atak/2;
            }
            else
            {
                if (other.tag == "Kitty")
                {
                    if (Player_Muwer.rid.kitis.Count < 10)
                    {
                        SoundPlayer.regit.Play(breake);
                        other.tag = "Neytral";
                        if (other.GetComponent<Point>())
                        {
                            other.GetComponent<Point>().Remaine();
                        }
                        else 
                        {
                            other.transform.parent.GetComponent<Point>().Remaine();
                        }

                        timer = Time.time + 0.2f;
                    }
                }
                if (other.tag == "Wall")
                {

                    timer = Time.time + 0.2f;
                    SoundPlayer.regit.Play(wall);
                    Vector3 vec = Player_Muwer.rid.transform.position - ps.position;
                    Player_Muwer.rid.rb.AddForce(vec * 800);
                }
            }
        }
       
    }
    private void FixedUpdate()
    {
        if (svordHelse < 100) 
        {
            svordHelse += Time.unscaledDeltaTime;
            if (svordHelse < 0) 
            {
                svordHelse = 0;
            }
        }
    }
}
