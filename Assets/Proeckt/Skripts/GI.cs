using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GI : MonoBehaviour
{
    public Image img, helse, amo;
    public Text hiscore, bilds, hels, ammo;
    private void FixedUpdate()
    {
        img.fillAmount = Gun.regit.relod / Gun.regit.relodTime;
        helse.fillAmount = Motor_Tank.regit.helse / 100;
        hels.text = (int)Motor_Tank.regit.helse + "%";
        amo.fillAmount = (float)Gun.regit.ammo / Gun.regit.max_Ammo;
        ammo.text = ""+ Gun.regit.ammo;
        string a = Interface.rid.bilds.ToString();
        hiscore.text =  " / " + YandexGame.savesData.record;
        bilds.text = "" + Interface.rid.bilds;
    }
}
