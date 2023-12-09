using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ClickerGameSystem : MonoBehaviour
{
    private enum GameState
    {
        Game,
        GameClear,
        GameFail
    }


    [SerializeField]
    private int maxScore;

    [SerializeField]
    private float timeLimit = 10;

    [SerializeField]
    private Text ui;
    [SerializeField]
    private GameObject ClickerObject;
    [SerializeField]
    private ParticleSystem effectA;
    [SerializeField]
    private ParticleSystem effectF;
    [SerializeField]
    private GameObject bar;

    private int score = 0;
    private float time = 0;
    private GameState gameState = GameState.Game;

    [SerializeField]
    private float ClickerObject_scaleTime = 0.02f;

    private float ClickerObject_originScale;
    private float ClickerObject_smallScale;
    private float ClickerObject_reduceScaleRatio = 0.95f;

    private void Start()
    {
        ClickerObject_originScale = ClickerObject.transform.localScale.x;
        ClickerObject_smallScale = ClickerObject_originScale * ClickerObject_reduceScaleRatio;
    }

    void Update()
    {
        if(gameState != GameState.Game)
        {
            return;
        }

        // 클리커 터치 이벤트 감지
        DetectTouch();


        ui.text = "Click : " + score;
        time += Time.deltaTime;
        bar.transform.LeanScaleX(time / timeLimit, 0f);

        GameFailHandle();
    }

    void DetectTouch()
    {
        // 터치 이벤트를 클리커가 처리하도록 수정
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleClickerTouch(Input.GetTouch(0).position);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            HandleClickerTouch(Input.mousePosition);
        }
    }

    void HandleClickerTouch(Vector2 inputPosition)
    {
        // 터치된 위치를 Ray로 변환
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        // 클리커에 Ray가 부딪히면 클릭으로 처리
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == ClickerObject)
        {
            AddScore();
            EventManager.TriggerEvent("OnCilckerClick");
        }
        else
        {
            TouchFailEffectStart();
        }
    }

    void AddScore()
    {
        score++;

        Shake();

        AddScoreEffectStart();

        GameClearHandle();
    }

    void GameClearHandle()
    {
        if (score == maxScore)
        {
            gameState = GameState.GameClear;
            EventManager.TriggerEvent("OnGameClear");
        }
    }

    void GameFailHandle()
    {
        if (gameState != GameState.GameClear && time >= timeLimit)
        {
            gameState = GameState.GameFail;
            EventManager.TriggerEvent("OnGameFail");
        }
    }

    void AddScoreEffectStart()
    {
        Invoke("AddScoreEffectEnd", 0.2f);
        effectA.Play();
    }

    void AddScoreEffectEnd()
    {
        effectA.Stop();
    }

    void TouchFailEffectStart()
    {
        effectF.Play();
        Invoke("TouchFailEffectEnd", 0.2f);
    }

    void TouchFailEffectEnd()
    {
        effectF.Stop();
    }

    void Shake()
    {
        Vector3 originScale = new Vector3(ClickerObject_originScale, ClickerObject_originScale, ClickerObject_originScale);

        ClickerObject.transform.DOKill();
        ClickerObject.transform.localScale = originScale;

        Vector3 smallScale = new Vector3(ClickerObject_smallScale, ClickerObject_smallScale, ClickerObject_smallScale);
        ClickerObject.transform.DOScale(smallScale, ClickerObject_scaleTime / 2)
            .SetLoops(2, LoopType.Yoyo);
    }
}