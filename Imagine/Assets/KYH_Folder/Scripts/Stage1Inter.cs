using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Inter : MonoBehaviour
{
    private CusionTutorial goToBad;
    public bool badEnter = false;
    public bool InBasket = false;
    new Transform transform;
    public GameObject cusion;
    public GameObject plsPress;
    private GameObject plsPressCusionPack;
    GameObject informationText;
    public static bool Lava;

    private void Awake()
    {
        //informationText = GameObject.Find("Information");
        plsPress = GameObject.Find("PushE");
        plsPressCusionPack = GameObject.Find("CusionPushInterface");
    }
    private void Start()
    {
        //informationText.SetActive(false);
        plsPress.SetActive(false);
        plsPressCusionPack.SetActive(false);
    }
    private void Update()
    {
        // eŰ�� ������ badenter�� true�� ����
        if (Input.GetKeyDown(KeyCode.E) && badEnter && Lava == false)
        {
            CusionTutorial.isCatch = true;
            plsPress.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.E) && InBasket)
        {

            //Instantiate(cusion);
            //cusion = null;
            CusionTutorial.isCatch = true;
            plsPress.SetActive(false);
            plsPressCusionPack.SetActive(false);
            Lava = false;
        }
        //if (Input.GetKeyDown(KeyCode.E) && badEnter)
        //{
        //    CusionTutorial.isCatch = true;
        //    plsPress.SetActive(false);
        //    informationText.SetActive(true); 
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ���� ģ���� cusion�±׸� ������ �ִٸ�
        if (collision.CompareTag("cusion"))
        {
            if (!Lava)
            {
                badEnter = true;
            goToBad = collision.gameObject.GetComponent<CusionTutorial>();
            transform = gameObject.GetComponentInParent<Transform>();
            goToBad.Hehe(transform);
                plsPress.SetActive(true);
            }
            print(transform.name);

            //cusion = cusion.gameObject;
            //PutOnCusion(cusion);
        }

        if (collision.CompareTag("Shoes"))
        {
            InBasket = true;
            plsPressCusionPack.SetActive(true);
            print(collision.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("cusion"))
        {
            badEnter = false;
            goToBad = null;
            transform = null;
            plsPress.SetActive(false);

        }
        if (collision.CompareTag("Shoes"))
        {
            plsPressCusionPack.SetActive(false);
            InBasket = false;
            print(collision.name);
        }
    }

    //public void PutOnCusion(GameObject OnCusion)
    //{
    //    OnCusion = cusion;
    //}
}
