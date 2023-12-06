using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTrackingManager : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager trackedImageManager;
    [SerializeField]
    private XRReferenceImageLibrary xRReferenceImages;

    [SerializeField]
    private List<SO_MarkerData> markerDatas;

    private GameObject runningGamePrefabs;

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            OnImageAdded(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            OnImageUpdated(trackedImage);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            OnImageRemoved(trackedImage);
        }
    }

    void OnImageAdded(ARTrackedImage trackedImage)
    {
        for (int i = 0; i < xRReferenceImages.count; i++)
        {
            if (trackedImage.referenceImage.name == xRReferenceImages[i].name)
            {
                if (runningGamePrefabs != null)
                {
                    Destroy(runningGamePrefabs);
                }
                EventManager.TriggerEvent("OnNewGame");
                runningGamePrefabs = Instantiate(markerDatas[i].gameDatas[0].gamePrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                break;
            }
        }
    }

    void OnImageUpdated(ARTrackedImage trackedImage)
    {
        // 필요에 따라 업데이트 처리를 추가할 수 있습니다.
    }

    void OnImageRemoved(ARTrackedImage trackedImage)
    {
        // 필요에 따라 제거 처리를 추가할 수 있습니다.
    }
}