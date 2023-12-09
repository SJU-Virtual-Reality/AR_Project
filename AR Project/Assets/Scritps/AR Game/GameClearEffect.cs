using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject gameclearEffect;

    private void Awake()
    {
        EventManager.Subscribe("OnGameClear", OnGameClear);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe("OnGameClear", OnGameClear);
    }

    private void OnGameClear()
    {
        gameclearEffect.SetActive(true);
    }
}
