using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Cinemachine;

public class Move : MonoBehaviour
{
    //DOMove(vector 원하는 위치, float 이동 시간, bool 스냅핑);
    //DOLocalMove(); // Local 좌표로도 이동 시킬 수도 있다.
    //transform.DOScale(targetScale, 3).SetEase(ease); 크기변경
    //transform.DORotate(new Vector3(0, -90, 0), 3) 회전
    //transform.DOShakeRotation(3) 흔들기
    public RectTransform rect;
    public Ease ease;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text;
    public TextMeshProUGUI startText;
    public GameObject textBoxMom;
    public GameObject textBoxKid;
    public GameObject camOn;
    public GameObject camTw;
    public bool mouse = false;
    public int textNum = 1;
    private float targetZoomSize;
    public CinemachineVirtualCamera camOne;
    public CinemachineVirtualCamera camTwo;
    private GameObject tutorial;
    private Animator animator;
    private GameObject shoes;

    private void Awake()
    {
        targetZoomSize = camOne.m_Lens.OrthographicSize;
        tutorial = GameObject.Find("Player");
        animator = GameObject.Find("LookUp").GetComponent<Animator>();
        shoes = GameObject.Find("Shoes");
    }

    private void Start()
    {
        text.text = "금방 갔다올게";
        TmPD0Text(text, 1.3f);
        tutorial.GetComponent<TutorialPlayer>().enabled = false;
        animator.SetFloat("vAxisRaw", 1);
        shoes.SetActive(false);
    }

    private void Update()
    {
        
        if(!(mouse))
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("발동!");
                textNum++;
                mouse = true;
                TextLine();
                mouse = false;
            }
        }
    }

    public static void TmPD0Text(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;

        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    void TextLine()
    {
        switch(textNum)
        {
            case 2:
                text.text = "기다리고 있으렴.";
                TmPD0Text(text, 1.3f);
                break;
            case 3:
                textBoxMom.SetActive(false);
                camTw.SetActive(false);
                camOn.SetActive(true);
                text2.text = "네";
                TmPD0Text(text, 1.3f);
                break;
            case 4:
                camTw.SetActive(true);
                camOn.SetActive(false);
                animator.SetFloat("vAxisRaw", 0);
                tutorial.GetComponent<TutorialPlayer>().enabled = true;
                startText.text = "집에서 뭐하고 놀아야할까?";
                TmPD0Text(startText, 1.3f);
                shoes.SetActive(true);
                break;
            case 5:

                break;
        }
    }

    public IEnumerator Typing(string talk)
    {
        text2.text = talk;
        TmPD0Text(text2, 3f);

        yield return new WaitForSecondsRealtime(1.5f);
        //NextTalk();
        print("끝");
    }
}
