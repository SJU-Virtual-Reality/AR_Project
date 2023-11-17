using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataController
{
    private static float gameVolume;
    private static float bgmVolume;
    private static float sfxVolume;

    public static float GameVolume
    { 
        get => gameVolume;
        set 
        {
            gameVolume = value;
            SaveData();
        }
    }
    public static float BgmVolume
    { 
        get => bgmVolume;
        set
        {
            bgmVolume = value;
            SaveData();
        }
    }
    public static float SfxVolume 
    { 
        get => sfxVolume;
        set
        {
            sfxVolume = value;
            SaveData();
        }
    }

    static DataController()
    {
        LoadData();
    }

    private static void SaveData()
    {
        PlayerPrefs.SetFloat("gameVolume", gameVolume);
        PlayerPrefs.SetFloat("bgmVolume", bgmVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.Save();
    }

    private static void LoadData()
    {
        gameVolume = PlayerPrefs.GetFloat("gameVolume", 100f);
        bgmVolume = PlayerPrefs.GetFloat("bgmVolume", 100f);
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 100f);
    }
}
