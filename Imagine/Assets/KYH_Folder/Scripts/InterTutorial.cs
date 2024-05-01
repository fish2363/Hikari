using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterTutorial : MonoBehaviour
{
    private CusionTutorial goToBad;
    public bool badEnter = false;
    new Transform transform;
    public GameObject cusion;
    private GameObject plsPress;
    private GameObject plsPressShoes;

    private void Awake()
    {
        plsPress = GameObject.Find("PushE");
        plsPressShoes = GameObject.Find("ShoesPushE");
    }
    private void Start()
    {
        plsPress.SetActive(false);
        plsPressShoes.SetActive(false);
    }
    private void Update()
    {
        // eŰ�� ������ badenter�� true�� ����
        if (Input.GetKeyDown(KeyCode.E) && badEnter)
        {
            CusionTutorial.isCatch = true;
            plsPress.SetActive(false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ���� ģ���� cusion�±׸� ������ �ִٸ�
        if (collision.CompareTag("cusion"))
        {
            badEnter = true;
            goToBad = collision.gameObject.GetComponent<CusionTutorial>();
            transform = gameObject.GetComponentInParent<Transform>();
            goToBad.Hehe(transform);
            plsPress.SetActive(true);
            print(transform.name);
            
            //cusion = cusion.gameObject;
            //PutOnCusion(cusion);
        }
        if (collision.CompareTag("Shoes"))
        {
            plsPressShoes.SetActive(true);
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
            cusion = null;
            plsPress.SetActive(false);

        }
        if (collision.CompareTag("Shoes"))
        {
            plsPressShoes.SetActive(false);
            print(collision.name);
        }
    }

    //public void PutOnCusion(GameObject OnCusion)
    //{
    //    OnCusion = cusion;
    //}
}
