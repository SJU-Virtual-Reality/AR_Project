using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public GameType gameClearData;

    [SerializeField]
    private GameObject gameClearUI;
    [SerializeField]
    private GameObject gameFailUI;

    private void Awake()
    {
        EventManager.Subscribe("OnGameClear", OnGameClear);
        EventManager.Subscribe("OnGameFail", OnGameFail);
        EventManager.Subscribe("OnNewGame", OnNewGame);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe("OnGameClear", OnGameClear);
        EventManager.Unsubscribe("OnGameFail", OnGameFail);
        EventManager.Unsubscribe("OnNewGame", OnNewGame);
    }

    private void OnGameClear()
    {
        gameClearUI.SetActive(true);
    }
    private void OnGameFail()
    {
        gameFailUI.SetActive(true);
    }
    private void OnNewGame()
    {
        gameClearUI.SetActive(false);
        gameFailUI.SetActive(false);
    }
}
