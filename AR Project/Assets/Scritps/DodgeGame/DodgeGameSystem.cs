using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeGameSystem : MonoBehaviour
{
    [SerializeField]
    private float clearTime = 5f;

    private bool isGameClear = false;
    private bool isGameOver = false;

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
        if (isGameClear || isGameOver)
        {
            return;
        }
        CancelInvoke("GameClearHandle");
        isGameOver = true;
        Debug.Log("GameOver...");
    }

    private void GameClearHandle()
    {
        isGameClear = true;
        Debug.Log("GameClear!");
    }
}
