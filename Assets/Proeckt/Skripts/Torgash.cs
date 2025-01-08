using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Torgash : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Invise")
        {
            anim.SetBool("Open",true);
            Droper_Inventar.rid.torg = true;
            for (int i = 0; i < Player_Muwer.rid.kitis.Count; i++)
            {
                Player_Muwer.rid.kitis[i].target = transform;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Invise") 
        {
            anim.SetBool("Open", false);
            Droper_Inventar.rid.torg = false;
        }
            
    }
}
