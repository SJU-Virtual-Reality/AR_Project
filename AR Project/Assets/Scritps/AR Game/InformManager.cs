using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObjects;
    [SerializeField]
    private GameObject informUI;

    [SerializeField]
    private float showInformTime = 3f;

    private void Awake()
    {
        EventManager.TriggerEvent("OnShowInform");
        gameObjects.SetActive(false);
        informUI.SetActive(true);
        Invoke("StartGame", showInformTime);
    }

    private void StartGame()
    {
        gameObjects.SetActive(true);
        informUI.SetActive(false);
    }
}
