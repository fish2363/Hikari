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
    GameObject changer2;
    bool stop = false;
    Animator kidAni;

    private void Awake()
    {
        kidAni = GameObject.Find("kidSprite").GetComponent<Animator>();
        changer2 = GameObject.Find("CameraChanger2");
        textBox = GameObject.Find("TextBoxUI");
        cam2 = GameObject.Find("cam02");
        camRightNow = GameObject.Find("PlayerCam");
    }

    private void Start()
    {
        changer2.SetActive(false);
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
            kidAni.SetBool("Walk", false);
            
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
                changer2.SetActive(true);
                GameManager.isAction = false;
                camRightNow.SetActive(true);
                cam2.SetActive(false);
                stop = false;
                textBox.SetActive(false);
                gameObject.SetActive(false);

            }
        }
    }
}
