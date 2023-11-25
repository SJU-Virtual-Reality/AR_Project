using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerGame : MonoBehaviour
{
    public Text ui;
    public GameObject GameClear;
    public GameObject GameFail;
    public GameObject Clicker;
    public ParticleSystem effectA;
    public GameObject effectF;

    private bool isClickerClicked = false;

    public void Increment()
    {
        if (GameManager.time == 20)
        {
            return;
        }
        GameManager.time += GameManager.multiplier;

        LeanTween.scale(Clicker, Vector3.one * 0.5f, 0.01f).setEaseOutQuad().setOnComplete(() =>
        {
            LeanTween.scale(Clicker, Vector3.one, 0.1f).setEaseInQuad();
        });

        if (effectA != null)
        {
            effectA.Play();
        }

        ActivateEffectF();
    }

    void Update()
    {
        ui.text = "Click : " + GameManager.time;
        if (GameManager.time == 20)
        {
            GameClear.SetActive(true);
        }
        else
        {
            GameClear.SetActive(false);
        }

        if (Bar.isAnimationComplete && GameManager.time != 20)
        {
            GameFail.SetActive(true);
        }
        else
        {
            GameFail.SetActive(false);
        }

        // 클리커 터치 이벤트 감지
        DetectTouch();
    }

    void DetectTouch()
    {
        // 터치 이벤트를 클리커가 처리하도록 수정
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleClickerTouch(Input.GetTouch(0).position);
        }

        if (Input.GetMouseButtonDown(0))
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
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == Clicker)
        {
            Increment();
        }
    }

    void ActivateEffectF()
    {
        if (effectF != null)
        {
            effectF.SetActive(true);
        }
    }
}