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
    private bool isGameOver = false;

    private void Update()
    {
        if (isGameClear || isGameOver)
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
            Debug.Log("GameClaer!");
            isGameClear = true;
            return;
        }



        // 게임 오버 처리
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
            Debug.Log("GameOver...");
            isGameOver = true;
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
