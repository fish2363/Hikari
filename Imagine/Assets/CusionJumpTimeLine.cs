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
    Transform kidSprite;
    GameObject kid;

    private void Awake()
    {
        player = GameObject.Find("Player");
        kidSprite = GameObject.Find("kidSprite").GetComponent<Transform>();
        textBox = GameObject.Find("TextBoxUITimeLineCusion");
        textBox.SetActive(false);
        kid = GameObject.Find("kidSprite");
    }

    public void End()
    {
        player.transform.position = kidSprite.position;
        kid.transform.localPosition = new Vector3(0, 0, 0);
        GameManager.isAction = false;
        gameObject.SetActive(false);
        GameObject.Find("inttaget").GetComponent<Stage1Inter>().enabled = true;

    }

    public static void TmPDOText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;

        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    IEnumerator Waitwo()
    {
        textBox.SetActive(true);
        text.text = "너무 높은데..\n방법이 없을까?";
        TmPDOText(text, 1f);
        yield return new WaitForSecondsRealtime(2);
        textBox.SetActive(false);
    }

    public void Text()
    {
        StartCoroutine(Waitwo());


    }
}
