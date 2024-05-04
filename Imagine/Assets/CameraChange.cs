using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class CameraChange : MonoBehaviour
{
    GameObject camRightNow;
    GameObject cam2;
    public GameObject textBox;
    TextMeshProUGUI text;

    private void Awake()
    {
        textBox = GameObject.Find("TextBox");
        cam2 = GameObject.Find("cam02");
        camRightNow = GameObject.Find("PlayerCam");
    }

    private void Start()
    {
        textBox.SetActive(false);
        cam2.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.isAction = true;
            camRightNow.SetActive(false);
            cam2.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    public static void TmPDOText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;

        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
        textBox.SetActive(true);
        text.text = "ħ�뿡���� �峭ġ�� ����� �ϼ̴µ�..\n������ �ٸ� �ޱ����� ���ư� �� �ִٰ� ���� ���� �־�\n������ �پ��";
        TmPDOText(text, 3f);
    }
}
