using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ClickerGame : MonoBehaviour
{

    public Text ui;
    public GameObject A;

    public void Increment()
    {
        if (GameManager.time == 20)
        {
            return;
        }
        GameManager.time += GameManager.multiplier;
    }

    void Update()
    {
        ui.text = "Click : " + GameManager.time;
        if (GameManager.time == 20)
        {
            A.SetActive(true);
        }
        else
        {
            A.SetActive(false);
        }
    }
}
