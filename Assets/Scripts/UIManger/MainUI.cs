using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] public int totalStrong = 1;
    [SerializeField] private TextMeshProUGUI titleStrong;
    [SerializeField] private Image imageField;
    [SerializeField] private TextMeshProUGUI NowBooster;
    [SerializeField] private TextMeshProUGUI ThenBooster;
    [SerializeField] public TextMeshProUGUI TimerTextAds;
    [SerializeField] public Transform WindowUpStrong;
    [SerializeField] public Transform WindowAds;
    [SerializeField] public Transform WindowSettings;
    [SerializeField] public Transform ButtonContinueAds;
    private int field = 50;
    public int click = 1;

    [field: SerializeField] public static MainUI Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
    private void Update()
    {
        UpdateTotalStrong();
        UpClick();
    }
    public int GetTotalStrong()
    {
        return totalStrong;
    }
    public void AddTotalStrong()
    {
        totalStrong += click;
    }
    public void AddTotalStrongReward(int reward)
    {
        totalStrong += reward;
    }
    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void RunGame()
    {
        Time.timeScale = 1;
    }
    public void UpdateTotalStrong()
    {
        titleStrong.SetText($"{totalStrong}");
    }
    public void UpClick()
    {
        if (field <= 0)
        {
            click += 1;
            UpdateUpStrong();
            field = 50;
            imageField.fillAmount = 0f;
        }
    }
    public void FeildDown()
    {
        field -= 1;
        imageField.fillAmount += 0.02f;
    }
    public void UpdateUpStrong()
    {
        NowBooster.SetText($"{click}");
        ThenBooster.SetText($"{click + 1}");
    }
}
