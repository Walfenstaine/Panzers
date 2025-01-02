using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class SoundButton : MonoBehaviour
{
    public Image image;
    public Sprite on, off;
    public AudioSource[] sorses;

    public void Onclicker() 
    {
        YandexGame.SaveProgress();
        YandexGame.savesData.soundOn = !YandexGame.savesData.soundOn;
        if (YandexGame.savesData.soundOn) 
        {
            image.sprite = on;
        }
        else
        {
            image.sprite = off;
        }
        for (int i = 0; i < sorses.Length; i++) 
        {
            sorses[i].enabled = YandexGame.savesData.soundOn;
        }
    }
}
