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
        text.text = "침대에서는 장난치지 말라고 하셨는데..\n위에서 뛰면 달까지도 날아갈 수 있다고 들은 적이 있어\n조심히 뛰어보자";
        TmPDOText(text, 3f);
    }
}
