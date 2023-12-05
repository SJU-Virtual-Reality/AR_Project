using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateGameSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject rotateObject;
    [SerializeField]
    private float rotateRate = 1f;
    [SerializeField]
    private float rotateTolerance = 1f;

    private bool isGameClear = false;

    private Camera mainCamera;

    private float prevCameraRotationZ;

    private void Awake()
    {
        mainCamera = Camera.main;
        prevCameraRotationZ = mainCamera.gameObject.transform.localRotation.eulerAngles.z;
    }

    private void Update()
    {
        if (isGameClear)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject == rotateObject)
                {
                    float deltaRotationZ = mainCamera.gameObject.transform.localRotation.eulerAngles.z - prevCameraRotationZ;
                    if (deltaRotationZ > 180f)
                    {
                        deltaRotationZ -= 360f;
                    }
                    if (deltaRotationZ < -180f)
                    {
                        deltaRotationZ += 360f;
                    }

                    float rotationY = rotateObject.transform.localRotation.eulerAngles.y + deltaRotationZ * rotateRate;

                    rotationY += 360f;
                    rotationY %= 360f;

                    Vector3 newRotation = Vector3.zero;
                    newRotation.x = 0f;
                    newRotation.y = rotationY;
                    newRotation.z = 180f;

                    rotateObject.transform.localRotation = Quaternion.Euler(newRotation);
                }
            }
        }

        if (rotateObject.transform.localRotation.eulerAngles.y > 180f - rotateTolerance
            && rotateObject.transform.localRotation.eulerAngles.y < 180f + rotateTolerance)
        {
            Vector3 answerRotation = Vector3.zero;
            answerRotation.x = 0f;
            answerRotation.y = 180f;
            answerRotation.z = 180f;
            rotateObject.transform.DOLocalRotate(answerRotation, 0.5f);
            isGameClear = true;
            Debug.Log("GameClear!");
        }

        prevCameraRotationZ = mainCamera.gameObject.transform.localRotation.eulerAngles.z;
    }
}
