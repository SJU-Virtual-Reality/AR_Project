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
    [field: Header("CorrectTounch")]
    [field: SerializeField] public EventReference gameCorrectTouchSound { get; private set; }
    [field: Header("WrongTouch")]
    [field: SerializeField] public EventReference gameWrongTouchSound { get; private set; }
    private void Awake()
    {
        EventManager.Subscribe("OnCilckerClick", playClickerClickSound);
        EventManager.Subscribe("OnGameClear", playGameClearSound);
        EventManager.Subscribe("OnGameFail", playGameFailSound);
        EventManager.Subscribe("OnCorrectTouch", playCorrectTouchSound);
        EventManager.Subscribe("OnWrongTouch", playWrongTouchSound);
    }
    private void OnDestroy()
    {
        EventManager.Unsubscribe("OnCilckerClick", playClickerClickSound);
        EventManager.Unsubscribe("OnGameClear", playGameClearSound);
        EventManager.Unsubscribe("OnGameFail", playGameFailSound);
        EventManager.Unsubscribe("OnCorrectTouch", playCorrectTouchSound);
        EventManager.Unsubscribe("OnWrongTouch", playWrongTouchSound);
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
    private void playCorrectTouchSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(gameCorrectTouchSound, transform.position);
    }
    private void playWrongTouchSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(gameWrongTouchSound, transform.position);
    }
}
