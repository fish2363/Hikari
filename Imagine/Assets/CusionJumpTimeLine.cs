using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CusionJumpTimeLine : MonoBehaviour
{
    public TextMeshProUGUI text;
    GameObject textBox;
    GameObject player;
    GameObject kidSprite;

    private void Awake()
    {
        player = GameObject.Find("Player");
        kidSprite = GameObject.Find("KidSprite");
        textBox = GameObject.Find("TextBoxUITimeLineCusion");
        textBox.SetActive(false);
    }

    public void End()
    {
        player.transform.position = kidSprite.transform.localPosition;
        GameManager.isAction = false;
        gameObject.SetActive(false);
    }

    public static void TmPDOText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;

        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    IEnumerator Waitwo()
    {
        textBox.SetActive(true);
        text.text = "�ʹ� ������..\n����� ������?";
        TmPDOText(text, 1f);
        yield return new WaitForSecondsRealtime(2);
        textBox.SetActive(false);
    }

    public void Text()
    {
        StartCoroutine(Waitwo());


    }
}
