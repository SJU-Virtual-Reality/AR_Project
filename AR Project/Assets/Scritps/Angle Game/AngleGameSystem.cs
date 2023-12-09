using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class AngleGameSystem : MonoBehaviour
{
    public TextMeshProUGUI disText;
    public Transform answerObject;

    public float answerDistance = 0.05f;

    private bool isGameClear = false;

    ARCameraManager arCameraManager;

    private void Start()
    {
        arCameraManager = Camera.main.GetComponent<ARCameraManager>();
    }

    void Update()
    {
        if (isGameClear)
        {
            return;
        }

        Vector3 cameraPosition = arCameraManager.transform.position;

        // AR 카메라와 정답 오브젝트 간의 거리 계산
        float distance = Vector3.Distance(cameraPosition, answerObject.position);

        float originalValue = distance;
        float roundedValue = Mathf.Round(originalValue * 100.0f) / 100.0f;
        disText.text = "distance : " + roundedValue;

        if (distance <= answerDistance)
        {
            EventManager.TriggerEvent("OnGameClear");
            disText.text = "";
            isGameClear = true;
            return;
        }
    }
}