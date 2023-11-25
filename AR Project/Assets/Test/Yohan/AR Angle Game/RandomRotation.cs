using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float minAngle = 0f; // 최소 각도
    public float maxAngle = 180f; // 최대 각도 (반구)

    void Start()
    {
        RandomAngle();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            RandomAngle();
        }
    }

    void RandomAngle()
    {
        // 무작위 각도 생성
        Vector3 randomAngle = new Vector3(0f, 0f, Random.Range(minAngle, maxAngle));

        // 무작위 각도로 1회만 회전
        transform.rotation = Quaternion.Euler(randomAngle);
    }
}
