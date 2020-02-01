using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private Animator playerControl;
    [SerializeField] private Animator girlIntroAnimationControl;
    [SerializeField] private Material grayscaleMat;

    [SerializeField] private GameObject[] levels;

    public void StopControlAnimation()
    {
        playerControl.enabled = false;
    }

    public IEnumerator StartGirlIntroAnimation()
    {
        yield return new WaitForSeconds(2);
        girlIntroAnimationControl.Play("girlfall_intro");
        yield return new WaitForSeconds(2);
        DoCamerashake();
        yield return new WaitForSeconds(4);
        yield return StartCoroutine(DoGrayScale());
        Debug.Log("Load level now");
        levels[0].SetActive(false);
        levels[1].SetActive(true);
        yield return StartCoroutine(FadeManager.Instance.BrightUp());
    }

    public void DoCamerashake()
    {
        Camera.main.GetComponent<CameraShake>().enabled = true;
    }

    public IEnumerator DoGrayScale()
    {
        float temp = 0f;
        float colourValue = 1f;
        while (temp < colourValue)
        {
            temp += Time.deltaTime;
            if (temp > 1)
            {
                grayscaleMat.SetFloat("_EffectAmount", 1);
            }
            else
            {
                grayscaleMat.SetFloat("_EffectAmount", temp);
            }

            yield return new WaitForEndOfFrame();
        }

        yield return StartCoroutine(FadeManager.Instance.BlackOut());

        Debug.Log("Do grayscale finished");
    }
}