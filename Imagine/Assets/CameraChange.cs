using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class CameraChange : MonoBehaviour
{
    GameObject camRightNow;
    GameObject cam2;
    GameObject textBox;
    public TextMeshProUGUI text;
    bool stop = false;

    private void Awake()
    {
        textBox = GameObject.Find("TextBoxUI");
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
        text.text = "ħ�뿡���� �峭ġ�� \n����� �ϼ̴µ�..";
        TmPDOText(text, 3f);
        yield return new WaitForSecondsRealtime(5);
        text.text = "�߸��ٸ� �ޱ���\n ���ư��ٰ� \n����ϼ̾�";
        TmPDOText(text, 3f);
        yield return new WaitForSecondsRealtime(4);
        text.text = "������ �پ��";
        TmPDOText(text, 2f);
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
                cam2.SetActive(false);
                stop = false;
                textBox.SetActive(false);
            }
        }
    }
}
