using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Lebar lebar;
    private Gotobad goToBad;
    public bool badEnter = false;
    private bool lebarEnter = false;
    new Transform transform;
    public GameObject cusion;

    
    private void Update()
    {
        // eŰ�� ������ badenter�� true�� ����
        if(Input.GetKeyDown(KeyCode.E) && badEnter)
        {
            Gotobad.isCatch = true;
        }
        else if (Input.GetKeyDown(KeyCode.E)&&lebarEnter)
        {
            if(!(lebar.isSwOn == true))
            {
                lebar.isSwOn = true;
            }
            else
            {
                lebar.isSwOn = false;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ���� ģ���� cusion�±׸� ������ �ִٸ�
        if (collision.CompareTag("cusion"))
        {
            badEnter = true;
            goToBad = collision.gameObject.GetComponent<Gotobad>();
            transform = gameObject.GetComponentInParent<Transform>();
            goToBad.Hehe(transform);
            print(transform.name);
            //cusion = cusion.gameObject;
            //PutOnCusion(cusion);
        }
        if (collision.CompareTag("Lebar"))
        {
            lebarEnter = true;
            lebar = collision.GetComponent<Lebar>();
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
        }
        if (collision.CompareTag("Lebar"))
        {
            lebarEnter = false;
        }
    }

    //public void PutOnCusion(GameObject OnCusion)
    //{
    //    OnCusion = cusion;
    //}
}
