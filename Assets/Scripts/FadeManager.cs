using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public IEnumerator BlackOut(CanvasGroup canvasGroup, float rate)
    {
        float colourValue = 1f;
        while (canvasGroup.alpha < colourValue)
        {
            canvasGroup.alpha += rate;
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator BrightUp(CanvasGroup canvasGroup, float rate)
    {
        float colourValue = 0f;
        while (canvasGroup.alpha > colourValue)
        {
            canvasGroup.alpha -= rate;
            yield return new WaitForEndOfFrame();
        }
    }
}
