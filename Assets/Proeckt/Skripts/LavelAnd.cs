using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using YG.Example;
public class LavelAnd : MonoBehaviour {
	public string level;
    public static LavelAnd rid { get; set; }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Reclame;
    }
    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Reclame;
    }
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

    public void OpenAds(int index) 
    {
        YandexGame.RewVideoShow(index);
    }
    public void Reclame(int id) 
    {
        if (id == 0)
        {
            Gun.regit.ammo = 30;
        }
        else 
        {
            Motor_Tank.regit.helse = 100;
        }
        Interface.rid.SaveGame();
        Interface.rid.Sum(1, true, 0);
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Main() 
    {
        SceneManager.LoadScene("StartScene");
        YandexGame.NewLeaderboardScores("LEADER666", YandexGame.savesData.record);
    }
    public void Next()
    {
        SceneManager.LoadScene(level);
    }
}
