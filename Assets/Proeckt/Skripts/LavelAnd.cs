using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
public class LavelAnd : MonoBehaviour {
	public string level;
    public static LavelAnd rid { get; set; }
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

    public void OpenAds() 
    {
        YandexGame.RewVideoShow(1);
    }
    public void Reclame() 
    {
        Interface.rid.Sum(1, true, 0);
        YandexGame.savesData.coins += 50;
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
