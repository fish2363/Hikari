using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Gotobad goToBad;
    public bool badEnter = false;

    private void Update()
    {
        // eŰ�� ������ badenter�� true�� ����
        if(Input.GetKeyDown(KeyCode.E) && badEnter)
        {
            goToBad.isCatch = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ���� ģ���� cusion�±׸� ������ �ִٸ�
        if (collision.CompareTag("cusion"))
        {
            badEnter = true;
            goToBad = collision.gameObject.GetComponent<Gotobad>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("cusion"))
        {
            badEnter = false;
            goToBad = null;
        }
    }

}
