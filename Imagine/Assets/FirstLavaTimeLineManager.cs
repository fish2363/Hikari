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
    GameObject playerColl;

    private void Awake()
    {
        playerColl = GameObject.Find("Player");
        player = GameObject.Find("kidSprite");
        textBox = GameObject.Find("TextBoxUITimeLine");
        textBox.SetActive(false);
    }

    public void Text()
    {
        //playerColl.transform.position += new Vector3(0, 1, 0);
        player.transform.localPosition = new Vector3(0f,-5.38f, 0f);
        GameManager.isAction = false;
        gameObject.SetActive(false);
        textBox.SetActive(false);
        playerColl.GetComponent<Collider2D>().enabled = true;
        playerColl.GetComponent<Rigidbody2D>().gravityScale = 1;
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
        playerColl.GetComponent<Collider2D>().enabled = true;
        playerColl.GetComponent<Rigidbody2D>().gravityScale = 1;

        yield return new WaitForSecondsRealtime(5);
    }

    public void TLEnd()
    {
        StartCoroutine(Waitwo());

        
    }
}
