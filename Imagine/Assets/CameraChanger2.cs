using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CameraChanger2 : MonoBehaviour
{
    GameObject camRightNow;
    GameObject cam3;
    GameObject textBox;
    public TextMeshProUGUI text;
    bool stop = false;

    private void Awake()
    {
        textBox = GameObject.Find("TextBoxUI");
        cam3 = GameObject.Find("cam03");
        camRightNow = GameObject.Find("PlayerCam");
    }

    private void Start()
    {
        textBox.SetActive(false);
        cam3.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.isAction = true;
            camRightNow.SetActive(false);
            cam3.SetActive(true);
            StartCoroutine(Waitwo());
        }
    }

    public static void TmPDOText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;

        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    IEnumerator Waitwo()
    {
        yield return new WaitForSecondsRealtime(2);
        textBox.SetActive(true);
        text.text = "쿠션이 든 바구니다.";
        TmPDOText(text, 3f);
        yield return new WaitForSecondsRealtime(5);
        text.text = "안에서 몇개 \n꺼내볼까?";
        TmPDOText(text, 3f);
        yield return new WaitForSecondsRealtime(4);
        stop = true;
    }
    private void Update()
    {
        if (stop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.isAction = false;
                camRightNow.SetActive(true);
                cam3.SetActive(false);
                stop = false;
                textBox.SetActive(false);
            }
        }
    }
}
