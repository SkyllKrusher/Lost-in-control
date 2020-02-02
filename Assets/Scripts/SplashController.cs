using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    [SerializeField] private GameObject cvGameLogo;
    [SerializeField] private GameObject cvGgjLogo;
    [SerializeField] private GameObject teamPanel;
    void Start()
    {
        StartCoroutine(StartSplash());
        cvGgjLogo.SetActive(false);
        cvGameLogo.SetActive(false);
        teamPanel.SetActive(true);
    }

    private IEnumerator StartSplash()
    {
        yield return StartCoroutine(FadeManager.Instance.BrightUp());
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeManager.Instance.BlackOut());
        teamPanel.SetActive(false);
        cvGameLogo.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(FadeManager.Instance.BrightUp());
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(FadeManager.Instance.BlackOut());
        cvGameLogo.SetActive(false);
        cvGgjLogo.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(FadeManager.Instance.BrightUp());
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(FadeManager.Instance.BlackOut());
        SceneManager.LoadScene(1);
    }

}
