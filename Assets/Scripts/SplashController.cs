using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    [SerializeField] private GameObject cvGameLogo;
    [SerializeField] private GameObject cvGgjLogo;
    void Start()
    {
        StartCoroutine(StartSplash());
        cvGgjLogo.SetActive(false);
        cvGameLogo.SetActive(true);
    }

    private IEnumerator StartSplash()
    {
        yield return StartCoroutine(FadeManager.Instance.BrightUp());
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(FadeManager.Instance.BlackOut());
        cvGameLogo.SetActive(false);
        cvGgjLogo.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(FadeManager.Instance.BrightUp());
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(FadeManager.Instance.BlackOut());
        SceneManager.LoadScene(1);
    }

}
