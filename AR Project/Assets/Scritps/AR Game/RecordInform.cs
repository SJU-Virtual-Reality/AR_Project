using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordInform : MonoBehaviour
{
    [SerializeField]
    private GameObject informUI;

    private void Awake()
    {
        EventManager.Subscribe("OnShowInform", OnShowInform);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe("OnShowInform", OnShowInform);
    }

    private void OnShowInform()
    {
        informUI.SetActive(false);
    }
}
