using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject opaquePlatform;
    [SerializeField] private GameObject translucentPlatform;
    [Space]
    [SerializeField] private float disappearDelayTime = 2f;
    [SerializeField] private float reappearDelayTime = 2f;

    private void OnCollisionEnter2D(Collision2D col)
    {
        HandleCollision(col);
    }

    private void HandleCollision(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(DisappearAndReapperPlatform(disappearDelayTime));
        }
    }

    private IEnumerator DisappearAndReapperPlatform(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        DisappearPlatform();
        StartCoroutine(ReappearAfterDelay(reappearDelayTime));
    }

    private IEnumerator ReappearAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ReappearPlatform();
    }

    private void DisappearPlatform()
    {
        opaquePlatform.SetActive(false);
        translucentPlatform.SetActive(true);
    }

    private void ReappearPlatform()
    {
        opaquePlatform.SetActive(true);
        translucentPlatform.SetActive(false);
    }
}
