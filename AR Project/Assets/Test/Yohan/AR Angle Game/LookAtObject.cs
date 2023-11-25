using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField]
    private GameObject answer;

    void Start()
    {
        transform.LookAt(answer.transform);
    }
}
