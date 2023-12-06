using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorGameSystem : MonoBehaviour
{
    [SerializeField]
    private List<MajorObject> correctMajorObjects;
    [SerializeField]
    private List<MajorObject> wrongMajorObjects;

    private bool isGameClear = false;
    private bool isGameFail = false;

    private void Update()
    {
        if (isGameClear || isGameFail)
        {
            return;
        }


        // 게임 클리어 처리
        bool allCorrectClicked = true;

        foreach (var majorObject in correctMajorObjects)
        {
            if (majorObject.isClicked == false)
            {
                allCorrectClicked = false;
                break;
            }
        }

        if (allCorrectClicked)
        {
            DisableAllMajorComponent();
            EventManager.TriggerEvent("OnGameClear");
            isGameClear = true;
            return;
        }



        // 게임 실패 처리
        bool anyWrongClicked = false;

        foreach (var majorObject in wrongMajorObjects)
        {
            
            if (majorObject.isClicked)
            {
                anyWrongClicked = true;
                break;
            }
        }

        if (anyWrongClicked)
        {
            DisableAllMajorComponent();
            EventManager.TriggerEvent("OnGameFail");
            isGameFail = true;
            return;
        }
    }

    private void DisableAllMajorComponent()
    {
        foreach (var majorObject in correctMajorObjects)
        {
            majorObject.enabled = false;
        }

        foreach (var majorObject in wrongMajorObjects)
        {
            majorObject.enabled = false;
        }
    }
}
