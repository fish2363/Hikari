using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Gotobad goToBad;
    public bool badEnter = false;
    new Transform transform;
    public GameObject cusion;

    private void Update()
    {
        // e키를 누르고 badenter가 true면 실행
        if(Input.GetKeyDown(KeyCode.E) && badEnter)
        {
            Gotobad.isCatch = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 만약 닿은 친구가 cusion태그를 가지고 있다면
        if (collision.CompareTag("cusion"))
        {
            badEnter = true;
            goToBad = collision.gameObject.GetComponent<Gotobad>();
            transform = gameObject.GetComponentInParent<Transform>();
            goToBad.Hehe(transform);
            print(transform.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("cusion"))
        {
            badEnter = false;
            goToBad = null;
            transform = null;
        }
    }
}
