using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendGameClearTypeMessage : MonoBehaviour
{
	GameManager gameManager;
	GameType clearGameType;

	void Awake()
	{
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		// 각 게임 클리어 이벤트 구독 (실행함수: onGameClear)
		EventManager.Subscribe("OnGameClear", onGameClear);
	}

	void Destroy()
	{
		// 각 게임 클리어 이벤트 해제
		EventManager.Unsubscribe("OnGameClear", onGameClear);
	}

	private void onGameClear()
	{
		string gameClearMessage;
		clearGameType = gameManager.gameClearData;
		gameClearMessage = clearGameType.ToString();
		
		sendClearDataToSwift(gameClearMessage);
	}

	public void sendClearDataToSwift(string gameClearMessage)
	{
		NativeAPI.sendMessageToMobileApp("Clear: " + gameClearMessage);
	}
}
