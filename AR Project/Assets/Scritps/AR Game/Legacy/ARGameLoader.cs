using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGameLoader : MonoBehaviour
{
    [SerializeField]
    private SO_MarkerData markerData;

    private GameObject currentGamePrefab;

    private void Awake()
    {
        CreateGameInstance();
    }

    private void CreateGameInstance()
    {
        int gameIndex = DataController.LoadGameData(markerData.name);

        if (gameIndex >= markerData.gameDatas.Count)
        {
            gameIndex = 0;
        }

        if(currentGamePrefab != null)
        {
            GameObject.Destroy(currentGamePrefab);
        }

        // 프리팹을 생성하여 변수에 저장
        currentGamePrefab = Instantiate(markerData.gameDatas[gameIndex].gamePrefab, transform.position, Quaternion.identity);

        // 생성된 프리팹을 현재 객체의 자식으로 설정
        currentGamePrefab.transform.parent = transform;
    }
}
