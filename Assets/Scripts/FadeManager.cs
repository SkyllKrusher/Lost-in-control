using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;
    private CanvasGroup myCanvasGroup;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        DontDestroyOnLoad(this);
        myCanvasGroup = this.GetComponent<CanvasGroup>();
    }

    void Start()
    {
    }

    public IEnumerator BlackOut()
    {
        float colourValue = 1f;
        float rate = 0.01f;
        while (myCanvasGroup.alpha < colourValue)
        {
            myCanvasGroup.alpha += rate;
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator BrightUp()
    {
        float colourValue = 0f;
        float rate = 0.01f;
        while (myCanvasGroup.alpha > colourValue)
        {
            myCanvasGroup.alpha -= rate;
            yield return new WaitForEndOfFrame();
        }
    }
}
