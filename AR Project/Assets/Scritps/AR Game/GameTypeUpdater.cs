using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTypeUpdater : MonoBehaviour
{
    [SerializeField]
    private GameType gameType;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.gameClearData = gameType;
    }
}
