using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingManager : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    [System.Serializable]
    public class ImagePrefabPair
    {
        public string imageName;
        public GameObject prefab;
    }

    public List<ImagePrefabPair> imagePrefabPairs = new List<ImagePrefabPair>();

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
        foreach (var pair in imagePrefabPairs)
        {
            if (trackedImage.referenceImage.name == pair.imageName)
            {
                Instantiate(pair.prefab, trackedImage.transform.position, trackedImage.transform.rotation);
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