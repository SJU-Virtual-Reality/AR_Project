using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGameSystem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectList;

    private bool isGameClear = false;

    private void Update()
    {
        if (isGameClear)
        {
            return;
        }

        // 마우스 클릭으로 오브젝트를 제거합니다.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                // 리스트에서 순서대로 검사하면서 클릭된 오브젝트를 찾고 제거합니다.
                for (int i = 0; i < objectList.Count; i++)
                {
                    if (objectList[i] == clickedObject)
                    {
                        if (i == 0)
                        {
                            Destroy(clickedObject);
                            objectList.RemoveAt(i);
                            Debug.Log("Object removed at index " + i);
                        }
                        else
                        {
                            Debug.Log("순서에 안맞는 클릭");
                        }
                        break; // 중복 제거 방지를 위해 루프를 종료합니다.
                    }
                }

                if(objectList.Count == 0)
                {
                    Debug.Log("GameClaer!");
                    isGameClear = true;
                }
            }
        }
    }
}
