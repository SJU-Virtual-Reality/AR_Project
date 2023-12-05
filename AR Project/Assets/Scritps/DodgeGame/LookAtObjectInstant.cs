using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookAtObjectInstant : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;

    private void Awake()
    {
        if (targetObject == null)
        {
            targetObject = Camera.main.gameObject;
        }
    }

    void Update()
    {
        transform.LookAt(targetObject.transform);
    }
}

