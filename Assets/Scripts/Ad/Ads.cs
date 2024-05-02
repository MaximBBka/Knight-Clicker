using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Ads : MonoBehaviour
{
    private float timer = 0f;
    private float timerPause = 3f;
    private int reawrdId = -1; // 0 - добавление кликак 1 - получение +300 силы

    private void Update()
    {
        if (!MainUI.Instance.WindowSettings.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 120f)
        {
            Time.timeScale = 0f;
            MainUI.Instance.WindowAds.gameObject.SetActive(true);
            MainUI.Instance.TimerTextAds.gameObject.SetActive(true);
            MainUI.Instance.TimerTextAds.SetText($"Реклама {MathF.Round(timerPause)}..");
            timerPause -= Time.unscaledDeltaTime;
            if (timerPause <= 0)
            {
                ShowAds();
                timerPause = 3f;
                MainUI.Instance.TimerTextAds.gameObject.SetActive(false);
                MainUI.Instance.ButtonContinueAds.gameObject.SetActive(true);
                timer = 0f;
            }
        }
    }
    public void RewardedAds(int index)
    {
        if (reawrdId == -1)
        {
            reawrdId = index;
            YandexGame.RewVideoShow(0);
        }
    }
    public void ShowAds()
    {
        if (!MainUI.Instance.WindowSettings.gameObject.activeSelf)
        {
            YandexGame.FullscreenShow();
        }
    }
    public void AddClick()
    {
        if (reawrdId == 0)
        {
            MainUI.Instance.click += 1;
            MainUI.Instance.UpdateUpStrong();
            Time.timeScale = 1f;
            reawrdId = -1;
        }
    }
    public void AdsStrong()
    {
        if (reawrdId == 1)
        {
            MainUI.Instance.totalStrong += 300;
            MainUI.Instance.UpdateTotalStrong();
            Time.timeScale = 1f;
            reawrdId = -1;
        }
    }
}
