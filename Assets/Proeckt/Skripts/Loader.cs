using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Loader : MonoBehaviour
{

    private void Start()
    {
        YandexGame.NewLeaderboardScores("LEADER666", YandexGame.savesData.record);
    }

    public void Starter()
    {
        YandexGame.savesData.lvl = "Scene1";
        YandexGame.savesData.coins = 30;
        YandexGame.savesData.record = 0;
        YandexGame.SaveProgress();
        YandexGame.NewLeaderboardScores("LEADER666", 0);
        SceneManager.LoadScene(YandexGame.savesData.lvl);
    }

    public void loader() 
    {
        SceneManager.LoadScene(YandexGame.savesData.lvl);
    }
}
