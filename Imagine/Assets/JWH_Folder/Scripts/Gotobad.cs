using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.Profiling;
using UnityEngine;

public class Gotobad : MonoBehaviour
{
    public GameObject player;
    public bool isCatch = false;
    private bool isShot;
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _Rigidbody2D;
    public Transform cusionUpTransform;
    private Transform plTransform;
    private Transform friendTransform;
    [SerializeField]private float speed = 16f;
    private LineRenderer _lineRenderer;
    private Vector3 movedir;
    private GameManager manager;
    private bool isDoubleJump;
    private IControllerPhysics[] playerControll;
    private Vector3 _transform;


    private void Awake()
    {
        _transform = transform.position;
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        plTransform = GameObject.Find("Player").GetComponent<Transform>();
        friendTransform  = GameObject.Find("Friend").GetComponent<Transform>();
    }
    public void Resetwow()
    {
        transform.position = _transform;
        this.gameObject.layer = 3;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        //if(GameManager.stopAni == 2 && isCatch == true)
        //{
        //    cusionUpTransform = friendTransform;
        //}
        //if (GameManager.stopAni == 1 && isCatch == true) cusionUpTransform = plTransform;
        if (Input.GetButtonDown("Fire1")) FallCusion();
        if (!(isCatch)) cusionUpTransform = null;


        Vector3 mousPos = Input.mousePosition;
        mousPos = Camera.main.ScreenToWorldPoint(mousPos);
        if (cusionUpTransform != null)
        {
            movedir = mousPos - cusionUpTransform.position;
            Vector3 mosp = mousPos - cusionUpTransform.position;
            if (Input.GetMouseButton(0) && isCatch)
            {

                DotDrawer.Instance.Show();
                DotDrawer.Instance.Draw(gameObject.transform.position, mosp.normalized * speed);
            }
            if (Input.GetMouseButtonUp(0) && isCatch)
            {

                DotDrawer.Instance.Clear();

                _boxCollider.enabled = true;
                _Rigidbody2D.AddForce(mosp.normalized * speed, ForceMode2D.Impulse);
                isCatch = false;
                isShot = true;
            }
            if (isCatch)
            {
                _Rigidbody2D.velocity = new Vector2(0, 0);
                gameObject.transform.position = cusionUpTransform.position + new Vector3(0, 0.5f, 0);
                _Rigidbody2D.gravityScale = 0;
                _boxCollider.enabled = false;
            }
            else
            {
                FallCusion();
            }
        }
        
    }


    public void FallCusion()
    {
        isCatch = false;
        _Rigidbody2D.gravityScale = 1;
        _boxCollider.enabled = true;
        transform.SetParent(null);
    }
            
    

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Tram"))
         {
            _Rigidbody2D.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
            if (isShot)
            {
                this.gameObject.layer = 0;
                isDoubleJump = true;
                isShot = false;
            }
        }
        if (collision.gameObject.CompareTag("Magema"))
        {
            this.gameObject.layer = 7;
        }
        
        
        if(isDoubleJump)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.rigidbody.AddForce(Vector2.up * 13f, ForceMode2D.Impulse);
                this.gameObject.layer = 3;
                isDoubleJump = false;
                collision.gameObject.GetComponent<IControllerPhysics>().isGround = false;
                collision.gameObject.GetComponentInChildren<Animator>().SetBool("Hoit", true);
            }
        }
    }

    public void Hehe(Transform trans)
    {
        trans = cusionUpTransform;
    }
}
