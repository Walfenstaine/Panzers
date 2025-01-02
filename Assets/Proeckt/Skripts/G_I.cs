using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class G_I : MonoBehaviour
{
    public Color norm, danger, blue;
    public Animator katama;
    public Text coins, record, kitty, kitty2, helser, svorder;
    public Image svord, helse;

    public static G_I rid { get; set; }
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
    public void Katana()
    {
        katama.SetTrigger("And");
    }

    private void FixedUpdate()
    {
        if (Player_Muwer.rid.kitis.Count >= 10)
        {
            kitty.color = danger;
            kitty2.color = danger;
        }
        else
        {
            kitty.color = norm;
            kitty2.color = norm;
        }
        if (Player_Muwer.rid.helse > 20)
        {
            helser.color = norm;
        }
        else 
        {
            helser.color = danger;
        }
        if (Sword.rid.svordHelse > 25)
        {
            svorder.color = blue;
        }
        else
        {
            svorder.color = danger;
        }
        helser.text = (int)Player_Muwer.rid.helse + "%";
        svorder.text = (int)Sword.rid.svordHelse + "%";
        coins.text = ": " + YandexGame.savesData.coins;
        record.text = ": " + YandexGame.savesData.record;
        svord.fillAmount = Sword.rid.svordHelse/100;
        helse.fillAmount = Player_Muwer.rid.helse / 100;
        kitty.text = ": " + Player_Muwer.rid.kitis.Count;
    }
}
