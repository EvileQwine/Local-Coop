using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.ParticleSystem;

public class ChainHealth : MonoBehaviour
{
    float maxChainHealth = 5;
    float currChainHealth;


    Color objectColor;
    Color fadeColor;

    bool flashing = false;

    public float fadeStart = 0f;
    float fadeTime = 2f;

    Renderer[] renderer;

    void Start()
    {
        currChainHealth = maxChainHealth;
        objectColor = Color.gray1;
        fadeColor = Color.ghostWhite;
        renderer = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currChainHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (flashing)
        {
            if (fadeStart < fadeTime)
            {
                fadeStart += Time.deltaTime * fadeTime;
                for (int i = 0; i < transform.childCount; i++)
                {
                    renderer[i].material.color = Color.Lerp(objectColor, fadeColor, fadeStart);
                }
            }
            else
            {
                fadeStart = 0;
            }
        }
    }
    public void Hit(int amount)
    {
        currChainHealth -= amount;
        StartCoroutine(FlashTimer());
    }
    IEnumerator FlashTimer()
    {
        flashing = true;
        yield return new WaitForSeconds(1.5f);
        flashing = false;
    }
}