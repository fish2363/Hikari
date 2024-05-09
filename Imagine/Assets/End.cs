using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class End : MonoBehaviour
{
    public TextMeshProUGUI textStart;
    GameObject textBox;
    public Image image;

    private void Awake()
    {
        textBox = GameObject.Find("TextBoxUI");
    }

    public static void TmPDOText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;

        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    // Update is called once per frame
    void Start()
    {
        textBox.SetActive(false);
        StartCoroutine(EndScene());
    }
    IEnumerator EndScene()
    {
        yield return new WaitForSecondsRealtime(3);

        textBox.SetActive(true);
        textStart.text = "뭐하고 있었어?";
        TmPDOText(textStart, 1f);
        yield return new WaitForSecondsRealtime(3);
        image.DOFade(1, 4);
    }
}
