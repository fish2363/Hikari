using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotobad : MonoBehaviour
{
    public Transform Transform12;
    public Transform transform1;
    public GameObject player;
    private PlayerMoveMent playerMoveMent;
    public bool isCatch = false;
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody2D;
    private Transform plTransform;
    private float speed = 10f;
    Vector3 movedir;
    private void Awake()
    {
       
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        playerMoveMent = player.GetComponent<PlayerMoveMent>();
        plTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {

        Vector3 mousPos = Input.mousePosition;
        mousPos = Camera.main.ScreenToWorldPoint(mousPos);
        movedir = mousPos - transform1.position;
        Vector2 mosp = mousPos - transform1.position;

        

        if (isCatch == true)
        {
            

            transform.SetParent(transform1);
            transform.position = plTransform.position + new Vector3(0, 2, 0); ;
            _boxCollider.enabled = false;

        }
        else
        {
            _boxCollider.enabled = true;
            transform.SetParent(null);
        }
        if (Input.GetMouseButtonDown(0) && isCatch==true)
        {
            _boxCollider.enabled = true;
            //transform.up = mosp.normalized;
            _rigidbody2D.AddForce(mosp.normalized * speed, ForceMode2D.Impulse);
            isCatch = false;
        }
    }
    
   
}
