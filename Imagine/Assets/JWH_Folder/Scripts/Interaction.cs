using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;
using UnityEngine.UIElements;

public class Interaction : MonoBehaviour
{

    public bool isActive = true;

    private Lebar lebar;
    private Gotobad goToBad;
    public bool badEnter = false;
    private bool lebarEnter = false;
    private bool holdEnter = false;
    new Transform transform;
    public GameObject cusion;
    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D circleCollider2D;
    private bool iswent;
    private bool isHolding;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        
    }
    private void Update()
    {
        if (!isActive) return;
        // e키를 누르고 badenter가 true면 실행
        //if(Input.GetKeyDown(KeyCode.E) && badEnter)
        //{
        //    Gotobad.isCatch = true;
        //}
        if (Input.GetKey(KeyCode.E))
        {
            iswent = true;
        }
        else
        {
            iswent = false;
        }
        if (Input.GetMouseButtonUp(0) && isHolding) 
        {
            isHolding = false;
        }
        {
            
        }
        if (Input.GetKeyDown(KeyCode.E)&&lebarEnter)
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
        if (holdEnter)
        {
            _rigidbody2D.gravityScale = 0;
            _rigidbody2D.velocity = Vector3.zero;
        }
        else if (!holdEnter)
        {
            _rigidbody2D.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive) return;
        if (collision != null)
        {
            // 만약 닿은 친구가 cusion태그를 가지고 있다면
            if (collision.CompareTag("cusion") && !isHolding)
            {
                badEnter = true;
                goToBad = collision.gameObject.GetComponent<Gotobad>();
                transform = gameObject.GetComponentInParent<Transform>();
                goToBad.Hehe(transform);
                //cusion = cusion.gameObject;
                //PutOnCusion(cusion);
            }
            if (collision.CompareTag("Lebar"))
            {
                lebarEnter = true;
                lebar = collision.GetComponent<Lebar>();
            }
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        
        if (collision.CompareTag("cusion"))
        {
            goToBad = collision.GetComponent<Gotobad>();
            if (badEnter && iswent && !isHolding)
            {
                if (!isActive) return;
                isHolding = true;
                goToBad.isCatch = true;
                goToBad.cusionUpTransform = transform.parent;
                

            }
        }
        
        if (collision.CompareTag("Holding") && Input.GetKey(KeyCode.Q))
        {
            holdEnter = true;
        }
        else
        {
            holdEnter = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isActive) return;
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
        if (collision.CompareTag("Holding"))
        {
            holdEnter=false;
        }


    }
    

    //public void PutOnCusion(GameObject OnCusion)
    //{
    //    OnCusion = cusion;
    //}
}
