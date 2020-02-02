using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private PlayerHandler playerHandler;
    [SerializeField] private Animator playerControl;
    [SerializeField] private Animator girlIntroAnimationControl;
    [SerializeField] private Material grayscaleMat;

    [SerializeField] private GameObject[] levels;
    [SerializeField] private List<Transform> levelStartingPositions;
    [SerializeField] private GameObject ghostGirl;
    [SerializeField] private Button reloadButton;

    private void OnEnable()
    {
        reloadButton.onClick.AddListener(() => ReloadLevel());
    }

    private void Start()
    {
        grayscaleMat.SetFloat("_EffectAmount", 0);
        TransitionLevel(1, 0);
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
        TransitionLevel(0, 1);
        yield return StartCoroutine(FadeManager.Instance.BrightUp());
        playerHandler.StartPlayerMovement();

    }

    public void TransitionLevel(int currentLevel, int newLevel, bool isReloadingLevel = false)
    {
        playerHandler.gameObject.transform.parent = null;

        //Debug.LogError("Current level " + currentLevel + "New Level " + newLevel);
        SetPlayerStartingPos(newLevel);
        levels[currentLevel].SetActive(false);
        levels[newLevel].SetActive(true);
        CustomGameManager.Instance.currentLevel = newLevel;
        SetButtonsStatus();

        if (newLevel != 0)
        {
            reloadButton.interactable = true;
        }
        else if (newLevel == 0)
        {
            reloadButton.interactable = false;
        }

        if (!isReloadingLevel && newLevel != 0)
        {
            CustomGameManager.Instance.playerHasKey = false;
            Invoke("PlayGhostAnim", 1f);
        }

    }

    public void ReloadLevel()
    {
        int currentLevel = CustomGameManager.Instance.currentLevel;
        if (currentLevel != 0)
        {
            TransitionLevel(CustomGameManager.Instance.currentLevel, CustomGameManager.Instance.currentLevel, true);
        }
    }

    public void SetButtonsStatus()
    {
        //Debug.LogError("Showing btn status..." + CustomGameManager.Instance.currentLevel);
        switch (CustomGameManager.Instance.currentLevel)
        {
            case (0):
                {
                    // do nothing
                    //Debug.LogError("Case 0 !");
                    break;
                }

            case (1):
                {
                    //Debug.LogError("Stting for lvl 1 btn status...");
                    CustomGameManager.Instance.isLeftBroken = true;
                    CustomGameManager.Instance.isRightBroken = true;
                    CustomGameManager.Instance.isJumpBroken = false;
                    CustomGameManager.Instance.ChangeButtonSprite(true, 0);
                    CustomGameManager.Instance.ChangeButtonSprite(true, 1);
                    CustomGameManager.Instance.ChangeButtonSprite(false, 2);
                    break;
                }

            case (2):
                {
                    //Debug.LogError("Stting for lvl 1 btn status...");
                    CustomGameManager.Instance.isLeftBroken = true;
                    CustomGameManager.Instance.isRightBroken = false;
                    CustomGameManager.Instance.isJumpBroken = false;
                    CustomGameManager.Instance.ChangeButtonSprite(true, 0);
                    CustomGameManager.Instance.ChangeButtonSprite(false, 1);
                    CustomGameManager.Instance.ChangeButtonSprite(false, 2);
                    break;
                }

            case (3):
                {
                    // TODO
                    break;
                }

            default:
                {
                    // do nothing
                    break;
                }
        }
    }

    private void PlayGhostAnim()
    {
        //Debug.LogError("Playing ghost girl anim.");
        ghostGirl.GetComponent<Animator>().SetTrigger("Level" + CustomGameManager.Instance.currentLevel.ToString());
    }

    private void SetPlayerStartingPos(int levelID)
    {
        playerHandler.gameObject.transform.position = levelStartingPositions[levelID].position;
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
