using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public AudioClip take;
    public LootIpe tipe;
    public enum LootIpe {bk, hill}

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (tipe == LootIpe.bk)
            {
                Gun.regit.ammo += 10;

            }
            else 
            {
                if (Motor_Tank.regit.helse < 70)
                {
                    Motor_Tank.regit.helse += 30;
                }
                else 
                {
                    Motor_Tank.regit.helse = 100;
                }
            }
            SoundPlayer.regit.Play(take);
            Destroy(gameObject);
        }
    }
}
