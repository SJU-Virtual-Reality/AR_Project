using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AngleGameTest : MonoBehaviour
{
    private GameObject mainCamera;

    [SerializeField]
    public Transform target; // 중심이 될 물체의 Transform
    [SerializeField]
    private float distance = 5.0f; // 카메라와 중심 물체 사이의 초기 거리
    [SerializeField]
    private float sensitivity = 2.0f; // 마우스 감도

    private Quaternion answerQuaternion;
    private float answerAngleDifference = 5f;
    private float answerMoveTime = 0.5f;

    private float currentX = 100.0f;
    private float currentY = 100.0f;

    private bool isClear = false;

    private void Start()
    {
        mainCamera = Camera.main.gameObject;

        answerQuaternion = Quaternion.Euler(0f, 0f, 0f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(isClear == false)
        {
            CameraHandle();
            ClearHandle();
        }
    }

    private void CameraHandle()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        currentY = Mathf.Clamp(currentY, -90f, 90f); // 위아래로 너무 돌아가지 않도록 제한

        // 마우스 움직임에 따라 카메라 위치 조절
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        mainCamera.transform.position = target.position + rotation * direction;
        mainCamera.transform.LookAt(target.position);
    }

    private void ClearHandle()
    {
        float angleDifference = Quaternion.Angle(mainCamera.transform.rotation, answerQuaternion);
        if (angleDifference < answerAngleDifference)
        {
            isClear = true;

            Vector3 direction = new Vector3(0, 0, -distance);
            Vector3 position = target.position + answerQuaternion * direction;
            mainCamera.transform.DOMove(position, answerMoveTime);
            mainCamera.transform.DORotateQuaternion(answerQuaternion, answerMoveTime);

            Debug.Log("Clear!");
        }
    }
}
