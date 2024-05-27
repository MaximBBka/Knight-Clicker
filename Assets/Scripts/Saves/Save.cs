using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using YG;

public class Save : MonoBehaviour
{
    private static int click;
    private static int totalStrong;
    private static int nowBooster;
    private static int thenBooster;
    private void Start()
    {
        Load();
        MainUI.Instance.totalStrong = totalStrong;
        MainUI.Instance.click = click;
        MainUI.Instance.UpdateUpStrong();
    }
    public static void Load()
    {
        YandexGame.LoadProgress();
        click = YandexGame.savesData.Clicker;
        totalStrong = YandexGame.savesData.Strong;
        if (totalStrong < MainUI.Instance.totalStrong)
        {
            totalStrong = MainUI.Instance.totalStrong;
            Saves();
        }
        if (click < MainUI.Instance.click)
        {
            click = MainUI.Instance.click;
            Saves();
        }
    }
    public static void Saves()
    {
        YandexGame.NewLeaderboardScores("LiderBoardStrong", totalStrong);
        YandexGame.savesData.Clicker = click;
        YandexGame.savesData.Strong = totalStrong;
        YandexGame.SaveProgress();
    }
}
