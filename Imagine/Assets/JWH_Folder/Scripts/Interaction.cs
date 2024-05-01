using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Lebar lebar;
    private Gotobad goToBad;
    public bool badEnter = false;
    bool lebarEnter = false;
    new Transform transform;
    public GameObject cusion;

    
    private void Update()
    {
        // e키를 누르고 badenter가 true면 실행
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
        // 만약 닿은 친구가 cusion태그를 가지고 있다면
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
        if (collision.CompareTag("Holding"))
        {
            Rigidbody2D _rigidbody2D = collision.GetComponentInParent<Rigidbody2D>();
            _rigidbody2D.gravityScale = 0;
            _rigidbody2D.velocity = Vector3.zero;
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
