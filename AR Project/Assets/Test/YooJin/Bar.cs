using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public int time;

    private bool isStopped = false;
    public static bool isAnimationComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
        StopAnimationIfNeeded();
    }

    public void AnimateBar()
    {
        if (!isStopped)
        {
            LeanTween.scaleX(bar, 1, time).setOnComplete(OnAnimationComplete);
        }
    }

    private void StopAnimationIfNeeded()
    {
        if (GameManager.time >= 20 && !isStopped)
        {
            LeanTween.cancel(bar);
            isStopped = true;
        }
    }

    private void OnAnimationComplete()
    {
        Bar.isAnimationComplete = true;
    }
}
