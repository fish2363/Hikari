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
    Animator kidAni;
    GameObject mouse;
    private void Awake()
    {
        textBox = GameObject.Find("TextBoxUI");
        cam3 = GameObject.Find("cam03");
        camRightNow = GameObject.Find("PlayerCam");
        kidAni = GameObject.Find("kidSprite").GetComponent<Animator>();
        mouse = GameObject.Find("Mouse");
        cam3.SetActive(false);
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
            cam3.SetActive(true);
            StartCoroutine(Waitwo());
            kidAni.SetBool("Walk", false);
            kidAni.SetBool("Hoit", false);
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
        text.text = "����� �� �ٱ��ϴ�.";
        TmPDOText(text, 3f);
        yield return new WaitForSecondsRealtime(5);
        text.text = "�ȿ��� � \n��������?";
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
                mouse.SetActive(false);
                GameManager.isAction = false;
                camRightNow.SetActive(true);
                cam3.SetActive(false);
                stop = false;
                textBox.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
