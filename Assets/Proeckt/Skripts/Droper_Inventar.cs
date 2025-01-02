using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class Droper_Inventar : MonoBehaviour
{
    public AudioClip kesh, non, drinck;
    public GameObject torgash;
    public Text text;
    public bool torg = false;
    public static Droper_Inventar rid { get; set; }
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
    private void FixedUpdate()
    {
        text.text = ": " + YandexGame.savesData.coins;
        torgash.SetActive(torg);
    }
    public void Hill() 
    {
        if (torg)
        {
            if (YandexGame.savesData.coins >= 50)
            {
                YandexGame.savesData.inv[1] += 1;
                YandexGame.savesData.coins -= 50;
                SoundPlayer.regit.Play(kesh);
            }
            else 
            {
                SoundPlayer.regit.Play(non);
            }
        }
        else
        {
            if (YandexGame.savesData.inv[1] > 0)
            {
                if (Player_Muwer.rid.helse < 100)
                {
                    if (Player_Muwer.rid.helse < 90)
                    {
                        Player_Muwer.rid.helse += 10;
                    }
                    else
                    {
                        Player_Muwer.rid.helse = 100;
                    }
                    SoundPlayer.regit.Play(drinck);
                    YandexGame.savesData.inv[1] -= 1;
                }
            }
        }
        Interface.rid.SaveGame();
    }

    public void Svoreder() 
    {
        Interface.rid.SaveGame();
        if (torg)
        {
            if (YandexGame.savesData.coins >= 50)
            {
                YandexGame.savesData.inv[0] += 1;
                YandexGame.savesData.coins -= 50;
                SoundPlayer.regit.Play(kesh);
            }
            else 
            {
                SoundPlayer.regit.Play(non);
            }
        }
        else 
        {
            if (YandexGame.savesData.inv[0] > 0)
            {
                if (Sword.rid.svordHelse < 100)
                {
                    if (Sword.rid.svordHelse < 60)
                    {
                        Sword.rid.svordHelse += 40;
                    }
                    else
                    {
                        Sword.rid.svordHelse = 100;
                    }
                    SoundPlayer.regit.Play(drinck);
                    YandexGame.savesData.inv[0] -= 1;
                }
            }
        }

        
    }

    public void Torg()
    {
        Interface.rid.SaveGame();
        if (torg)
        {
            if (YandexGame.savesData.coins >= 50)
            {
                YandexGame.savesData.inv[2] += 1;
                YandexGame.savesData.coins -= 50;
                SoundPlayer.regit.Play(kesh);
            }
            else 
            {
                SoundPlayer.regit.Play(non);
            }
        }
        else
        {
            if (YandexGame.savesData.inv[2] > 0)
            {
                SoundPlayer.regit.Play(drinck);
                Player_Muwer.rid.Invise();
                YandexGame.savesData.inv[2] -= 1;
            }
        }
    }
}
