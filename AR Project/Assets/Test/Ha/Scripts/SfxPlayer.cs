using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SfxPlayer : MonoBehaviour
{
    [field: Header("Clicker Click Success")]
    [field: SerializeField] public EventReference clickerClick { get; private set; }
    [field: Header("GameClear")]
    [field: SerializeField] public EventReference gameClearSound { get; private set; }
    [field: Header("GameFail")]
    [field: SerializeField] public EventReference gameFailSound { get; private set; }
    private void Awake()
    {
        EventManager.Subscribe("OnCilckerClick", playClickerClickSound);
        EventManager.Subscribe("OnGameClear", playGameClearSound);
        EventManager.Subscribe("OnGameFail", playGameFailSound);
    }
    private void OnDestroy()
    {
        EventManager.Unsubscribe("OnCilckerClick", playClickerClickSound);
        EventManager.Unsubscribe("OnGameClear", playGameClearSound);
        EventManager.Unsubscribe("OnGameFail", playGameFailSound);
    }

    private void playClickerClickSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(clickerClick, transform.position);
    }
    private void playGameClearSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(gameClearSound, transform.position);
    }
    private void playGameFailSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(gameFailSound, transform.position);
    }
}
