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
        GameDataCheck();


        LoadData();
    }

    private static void GameDataCheck()
    {
        if (PlayerPrefs.GetString("FirstPlay") != "True")
        {
            PlayerPrefs.SetString("FirstPlay", "True");

            PlayerPrefs.SetString("GameClearData_" + GameType.Angle1.ToString(), "False");
            PlayerPrefs.SetString("GameClearData_" + GameType.Angle2.ToString(), "False");
            PlayerPrefs.SetString("GameClearData_" + GameType.Clicker.ToString(), "False");
            PlayerPrefs.SetString("GameClearData_" + GameType.Dodge.ToString(), "False");
            PlayerPrefs.SetString("GameClearData_" + GameType.Major.ToString(), "False");
            PlayerPrefs.SetString("GameClearData_" + GameType.Order.ToString(), "False");
            PlayerPrefs.SetString("GameClearData_" + GameType.Rotate.ToString(), "False");

            PlayerPrefs.Save();
        }
    }



    public static void SaveGameData(string markerName, int gameIndex)
    {
        PlayerPrefs.SetInt("GameData_" + markerName, gameIndex);
        PlayerPrefs.Save();
    }

    public static int LoadGameData(string markerName)
    {
        return PlayerPrefs.GetInt("GameData_" + markerName, 0);
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
