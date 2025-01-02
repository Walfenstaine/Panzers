using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class AddKitty : MonoBehaviour
{
    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TNT")
        {
            SoundPlayer.regit.Play(clip);
            YandexGame.savesData.record += 1;
            YandexGame.savesData.coins += 5;
            YandexGame.NewLeaderboardScores("LEADER666", YandexGame.savesData.record);
            YandexGame.SaveProgress();
            Destroy(other.gameObject);
        }
        else 
        {
            if (other.tag == "Player") 
            {
                YandexGame.SaveProgress();
                YandexGame.NewLeaderboardScores("LEADER666", YandexGame.savesData.record);
                Interface.rid.Sum(3,true,0);
            }
        }
    }
}
