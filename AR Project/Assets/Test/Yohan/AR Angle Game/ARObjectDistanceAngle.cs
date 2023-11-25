using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARObjectDistanceAngle : MonoBehaviour
{
    public TextMeshProUGUI angText;
    public TextMeshProUGUI disText;
    public Transform augmentedObject;
    public Transform answerObject;

    ARCameraManager arCameraManager;

    private void Start()
    {
        arCameraManager = Camera.main.GetComponent<ARCameraManager>();
    }

    void Update()
    {
        Vector3 cameraPosition = arCameraManager.transform.position;

        // AR 카메라와 정답 오브젝트 간의 거리 계산
        float distance = Vector3.Distance(cameraPosition, answerObject.position);
        disText.text = "distance: " + distance;

        // AR 카메라와 증강된 오브젝트 간의 각도 차이 계산
        Vector3 directionToTarget = augmentedObject.position - cameraPosition;
        float angle = Vector3.Angle(arCameraManager.transform.forward, directionToTarget);
        angText.text = "angle: " + angle;
    }
}