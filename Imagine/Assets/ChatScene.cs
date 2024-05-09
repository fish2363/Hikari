using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ChatScene : MonoBehaviour
{
    public TextMeshProUGUI textStart;
    GameObject textBox;
    public TextMeshProUGUI textStart2;
    GameObject textBox2;
    public SpriteRenderer panel;
    public SpriteRenderer cave;
    float time = 0f;
    float F_time = 1f;

    private void Awake()
    {
        textBox = GameObject.Find("TextBoxUI");
        textBox2 = GameObject.Find("TextBoxUI2");
    }

    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        textBox2.SetActive(false);
        StartCoroutine(Waitwo());
    }

    public static void TmPDOText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;

        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    IEnumerator Waitwo()
    {
        yield return new WaitForSecondsRealtime(5);

        textBox.SetActive(true);
        textStart.text = "재미없다..";
        TmPDOText(textStart, 1f);
        yield return new WaitForSecondsRealtime(3);
        textStart.text = "음..";
        TmPDOText(textStart, 1f);
        yield return new WaitForSecondsRealtime(3);
        textStart.text = "다른 게 \n필요해";
        TmPDOText(textStart, 3f);
        yield return new WaitForSecondsRealtime(5);
        textStart.text = "..무슨 재미있는\n상상이 없을까";
        TmPDOText(textStart, 2f);
        yield return new WaitForSecondsRealtime(5);
        textStart.text = "흠..보자";
        TmPDOText(textStart, 2f);
        yield return new WaitForSecondsRealtime(3);
        textBox.SetActive(false);
        Color alpha = panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
        }
        yield return null;
        time = 0f;
        textBox2.SetActive(true);
        textStart2.text = "내가 동굴에 있는거야";
        TmPDOText(textStart2, 2f);
        yield return new WaitForSecondsRealtime(5);
        panel.DOFade(0, 2);
        cave.DOFade(1, 3);
        yield return new WaitForSecondsRealtime(5);
        textStart2.text = "그래 이거지";
        TmPDOText(textStart2, 2f);
    }
}
