using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using YG;

public class Save : MonoBehaviour
{
    private int click;
    private int totalStrong;
    private void Start()
    {
        Load();
        MainUI.Instance.totalStrong = totalStrong;
        MainUI.Instance.click = click;
    }
    public void Load()
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
    public void Saves()
    {
        YandexGame.savesData.Clicker = click;
        YandexGame.savesData.Strong = totalStrong;
        YandexGame.SaveProgress();
    }
}
