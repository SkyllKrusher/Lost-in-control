using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private PlayerHandler playerHandler;
    [SerializeField] private Animator playerControl;
    [SerializeField] private Animator girlIntroAnimationControl;
    [SerializeField] private Material grayscaleMat;

    [SerializeField] private GameObject[] levels;

    private void Start()
    {
        grayscaleMat.SetFloat("_EffectAmount", 0);
        levels[0].SetActive(true);
        levels[1].SetActive(false);
    }

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
        CustomGameManager.Instance.currentLevel += 1;
        yield return StartCoroutine(FadeManager.Instance.BrightUp());
        playerHandler.StartPlayerMovement();

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
        grayscaleMat.SetFloat("_EffectAmount", 0);
        Debug.Log("Do grayscale finished");
    }
}