using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookAtObjectGently : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private float followDelay = 0.5f;

    void Update()
    {
        transform.DOKill();
        transform.DORotate(targetTransform.rotation.eulerAngles, followDelay).SetEase(Ease.Linear);
    }


    private void OnTriggerEnter(Collider other)
    {
        EventManager.TriggerEvent("DodgeGame_OnTriggerEnter");
    }
}
