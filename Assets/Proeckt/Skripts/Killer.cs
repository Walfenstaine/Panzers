using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static YG.LBPlayerDataYG;

public class Killer : MonoBehaviour
{
    public Transform bodey;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player_Muwer.rid.rb.AddForce(bodey.forward * 300);
            Player_Muwer.rid.Damag();
        }
    }
}
