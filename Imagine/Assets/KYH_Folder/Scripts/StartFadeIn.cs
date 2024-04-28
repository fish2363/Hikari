using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartFadeIn : NextYear
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    // Start is called before the first frame update

    public void Update()
    {
        if(fadeOut)
        {
            StartCoroutine(FadeIn());
            Debug.Log("ÆäÀÌµå¾Æ¿ô");
        }
        else if (fadeIn)
        {
            StartCoroutine(FadeOut());
        }
    }

    public IEnumerator FadeOut()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        time = 0f;
    }

    public IEnumerator FadeIn()
    {
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        time = 0f;
    }

    void Start()
    {
        StartCoroutine(FadeOut());
    }
}
