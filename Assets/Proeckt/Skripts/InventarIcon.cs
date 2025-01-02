using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class InventarIcon : MonoBehaviour
{
    public int index_Num;
    public Data data;
    public Image img;
    public Text text;


    private void FixedUpdate()
    {
        text.text = "" + YandexGame.savesData.inv[index_Num];
    }
}
