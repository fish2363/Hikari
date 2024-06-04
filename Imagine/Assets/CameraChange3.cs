using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CameraChange3 : MonoBehaviour
{
    GameObject camRightNow;
    GameObject cam4;
    GameObject textBox;
    public TextMeshProUGUI text;
    bool stop = false;
    Animator kidAni;
    GameObject mouse;

    private void Awake()
    {
        textBox = GameObject.Find("TextBoxUIUp");
        cam4 = GameObject.Find("cam04");
        camRightNow = GameObject.Find("PlayerCam");
        kidAni = GameObject.Find("kidSprite").GetComponent<Animator>();
        mouse = GameObject.Find("Mouse");
        cam4.SetActive(false);
    }

    private void Start()
    {
        textBox.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.isAction = true;
            camRightNow.SetActive(false);
            cam4.SetActive(true);
            StartCoroutine(Waitwo());
            kidAni.SetBool("Walk", false);

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
        text.text = "���� �Ѿ�⿣\n�ʹ� ������..";
        TmPDOText(text, 3f);
        yield return new WaitForSecondsRealtime(5);
        text.text = "����� ��Ͽ�\n������ �ǳʰ���";
        TmPDOText(text, 3f);
        yield return new WaitForSecondsRealtime(4);
        stop = true;
        mouse.SetActive(true);
    }
    private void Update()
    {
        if (stop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameObject.SetActive(false);
                GameManager.isAction = false;
                camRightNow.SetActive(true);
                cam4.SetActive(false);
                stop = false;
                textBox.SetActive(false);
                mouse.SetActive(false);
            }
        }
    }
}
