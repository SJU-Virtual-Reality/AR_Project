using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    [Range(0, 1)]
    public float masterVolume;
    [Range(0, 1)]
    public float bgmVolume;
    [Range(0, 1)]
    public float sfxVolume;

    private Bus masterBus;
    private Bus bgmBus;
    private Bus sfxBus;

    private void Awake()
    {
        sfxVolume = DataController.SfxVolume / 100.0f;
        bgmVolume = DataController.BgmVolume / 100.0f;
        masterVolume = DataController.GameVolume / 100.0f;
        masterBus = RuntimeManager.GetBus("bus:/");
        bgmBus = RuntimeManager.GetBus("bus:/bgm");
        sfxBus = RuntimeManager.GetBus("bus:/sfx");
    }

    // Update is called once per frame
    void Update()
    {
        masterBus.setVolume(masterVolume);
        bgmBus.setVolume(bgmVolume);
        sfxBus.setVolume(sfxVolume);
    }

    public void setMasterVolume(string newMasterVolume)
    {
        masterVolume = (float.Parse(newMasterVolume));
    }
    public void setBgmVolume(string newBgmVolume)
    {
        bgmVolume = (float.Parse(newBgmVolume));
    }
    public void setSfxVolume(string newSfxVolume)
    {
        sfxVolume = (float.Parse(newSfxVolume));
    }
}
