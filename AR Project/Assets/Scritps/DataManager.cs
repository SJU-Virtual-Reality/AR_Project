using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	GameManager gameManager;
	GameType clearGameType;

	void Awake()
	{
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

		EventManager.Subscribe("OnGameClear", OnGameClear);
	}

	void Destroy()
	{
		EventManager.Unsubscribe("OnGameClear", OnGameClear);
	}

	private void OnGameClear()
	{
		string gameClearMessage;
		clearGameType = gameManager.gameClearData;
		gameClearMessage = "GameClearData_" + clearGameType.ToString();

		PlayerPrefs.SetString(gameClearMessage, "True");
		PlayerPrefs.Save();
	}
}
