using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FirstLavaTimeLineManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    GameObject textBox;
    GameObject player;
    Vector3 playerVector;

    private void Awake()
    {
        player = GameObject.Find("kidSprite");
        textBox = GameObject.Find("TextBoxUITimeLine");
        textBox.SetActive(false);
        playerVector = GameObject.Find("kidSprite").GetComponentInParent<Transform>().position;
    }

    public void Text()
    {
        player.transform.localPosition = new Vector3(0,0, 0);
        GameManager.isAction = false;
        gameObject.SetActive(false);
        textBox.SetActive(false);
    }

    public static void TmPDOText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;

        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    IEnumerator Waitwo()
    {
        textBox.SetActive(true);
        text.text = "용암이 올라오면\n위에 매달려야겠어";
        TmPDOText(text, 3f);
        yield return new WaitForSecondsRealtime(5);
    }

    public void TLEnd()
    {
        StartCoroutine(Waitwo());

        
    }
}
