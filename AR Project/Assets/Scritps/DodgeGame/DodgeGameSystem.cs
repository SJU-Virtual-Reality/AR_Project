using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeGameSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private float clearTime = 5f;

    private bool isGameClear = false;
    private bool isGameFail = false;

    private void Awake()
    {
        EventManager.Subscribe("DodgeGame_OnTriggerEnter", DodgeGame_OnTriggerEnter);
    }

    private void Start()
    {
        Invoke("GameClearHandle", clearTime);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe("DodgeGame_OnTriggerEnter", DodgeGame_OnTriggerEnter);
    }

    private void DodgeGame_OnTriggerEnter()
    {
        if (isGameClear || isGameFail)
        {
            return;
        }
        CancelInvoke("GameClearHandle");
        isGameFail = true;
        EventManager.TriggerEvent("OnGameFail");
    }

    private void GameClearHandle()
    {
        isGameClear = true;
        EventManager.TriggerEvent("OnGameClear");
        laser.SetActive(false);
    }
}
