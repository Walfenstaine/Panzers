using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using YG;

public class Interface : MonoBehaviour
{
    public int bilds;
    public UnityEvent[] sumer;
    public static Interface rid { get; set; }

    void Awake()
    {
        YandexGame.NewLeaderboardScores("LEADER666", YandexGame.savesData.record);
        YandexGame.SaveProgress();
        Sum(1, true, 0);
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
    public void Sum(int index, bool cursor, float scale)
    {
        sumer[index].Invoke();
        CursorEvent(cursor);
        Time.timeScale = scale;
    }
    public void SaveGame() 
    {
        YandexGame.NewLeaderboardScores("LEADER666", YandexGame.savesData.record);
        YandexGame.SaveProgress();

    }

    void CursorEvent(bool activ)
    {
        if (activ)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = activ;
    }
}
