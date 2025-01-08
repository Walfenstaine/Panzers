using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Loot : MonoBehaviour
{
    public int index_Icon;
    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Invise")
        {
            if (index_Icon <= 2)
            {
                YandexGame.savesData.inv[index_Icon] += 1;
            }
            else 
            {
                YandexGame.savesData.coins += Random.Range(1,3);
            }
            SoundPlayer.regit.Play(clip);
            
            Destroy(gameObject);
            Interface.rid.SaveGame();
        }
    }
}
