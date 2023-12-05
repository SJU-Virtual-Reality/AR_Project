using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EventManager.TriggerEvent("DodgeGame_OnTriggerEnter");
    }
}
