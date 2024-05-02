using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [field: SerializeField] public AudioSource Music { get; private set; } 
    //[field: SerializeField] public AudioSource Volume { get; private set; }
    public static Audio Instance { get; private set; }
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
    private void Start()
    {
        float musicvalue = Audio.Instance.Music.volume;

        if (PlayerPrefs.HasKey("Music"))
        {
            musicvalue = PlayerPrefs.GetFloat("Music");
        }
        PlayerPrefs.SetFloat("Music", musicvalue);
        Audio.Instance.Music.volume = musicvalue;
        //float volumevalue = Audio.Instance.Volume.volume;
        //if (PlayerPrefs.HasKey("Volume"))
        //{
        //    volumevalue = PlayerPrefs.GetFloat("Volume");
        //}
        //PlayerPrefs.SetFloat("Volume", volumevalue);
        //Audio.Instance.Volume.volume = volumevalue;
    }
}
