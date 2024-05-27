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
    private int reawrdId = -1; // 0 - ���������� ������ 1 - ��������� +300 ����

    private void Update()
    {
        if (!MainUI.Instance.WindowSettings.gameObject.activeSelf && !MainUI.Instance.WindowAds.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 120f)
        {
            MainUI.Instance.StopGame();
            MainUI.Instance.WindowAds.gameObject.SetActive(true);
            MainUI.Instance.TimerTextAds.gameObject.SetActive(true);
            if (YandexGame.EnvironmentData.language == "ru")
            {
                MainUI.Instance.TimerTextAds.text = $"������� {MathF.Round(timerPause)}..";

            }else if (YandexGame.EnvironmentData.language == "en")
            {
                MainUI.Instance.TimerTextAds.text = $"Advertisement {MathF.Round(timerPause)}..";
            }else if(YandexGame.EnvironmentData.language == "tr")
            {
                MainUI.Instance.TimerTextAds.text = $"Reklam {MathF.Round(timerPause)}..";
            }
            timerPause -= Time.unscaledDeltaTime;
            if (timerPause <= 0)
            {
                ShowAds();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
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
