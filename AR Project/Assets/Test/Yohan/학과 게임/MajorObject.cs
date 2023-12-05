using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorObject : MonoBehaviour
{
    private MeshRenderer rendererComponenet;

    [HideInInspector]
    public bool isClicked = false;

    private void Awake()
    {
        rendererComponenet = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (isClicked)
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

                if (clickedObject == this.gameObject)
                {
                    rendererComponenet.enabled = false;
                    isClicked = true;
                }
            }
        }
    }
}
