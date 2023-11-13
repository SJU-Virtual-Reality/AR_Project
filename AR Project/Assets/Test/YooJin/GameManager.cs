using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int time;
    public static int multiplier;

    void Start()
    {
       multiplier = 1;
       time = 0;
    }

}
