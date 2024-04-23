using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Profiling;
using UnityEngine;

public class Gotobad : MonoBehaviour
{
    public GameObject player;
    public bool isCatch = false;
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody2D;
    private Transform plTransform;
    private float speed = 15f;
    private LineRenderer _lineRenderer;
    Vector3 movedir;


    //public GameObject dotPre;
    //public int numDots;
    //public float dotSp;

    //private GameObject[] traDot;
    //private Vector2 iposition;
    //private Vector2 ivelocity;
    //private Vector2 gravity;
    //private float timeStep;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        //traDot = new GameObject[numDots];
        //gravity = Physics2D.gravity;
        //timeStep = Time.fixedDeltaTime;
        //for (int i = 0; i < numDots; i++)
        //{
        //    traDot[i] = Instantiate(dotPre, transform);
        //}
        plTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        
        Vector3 mousPos = Input.mousePosition;
        mousPos = Camera.main.ScreenToWorldPoint(mousPos);
        movedir = mousPos - plTransform.position;
        Vector3 mosp = mousPos - plTransform.position;

        if (Input.GetMouseButton(0) && isCatch)
        {
            //iposition = transform.position; // 위치 저장

            //ivelocity = mosp.normalized * speed; // 힘 주기

            //UpdateTr(); // 예측 함수 호출
            DotDrawer.Instance.Show();
            DotDrawer.Instance.Draw(transform.position, mosp.normalized * speed);
        }
        

        if (Input.GetMouseButtonUp(0) && isCatch)
        {

            DotDrawer.Instance.Clear();
            //foreach (var dot in traDot)
            //{
            //    dot.SetActive(false);
            //}
            Debug.Log("ssss");
            _boxCollider.enabled = true;
            //transform.up = mosp.normalized;
            _rigidbody2D.AddForce(mosp.normalized * speed, ForceMode2D.Impulse);
            isCatch = false;
            
        }


        if (isCatch)
        {
            _rigidbody2D.velocity = new Vector2(0, 0);
            transform.SetParent(plTransform);
            transform.position = plTransform.position + new Vector3(0, 0.5f, 0);
            _rigidbody2D.gravityScale = 0;
            _boxCollider.enabled = false;
            

        }
        else
        {
            _rigidbody2D.gravityScale = 1;
            _boxCollider.enabled = true;
            transform.SetParent(null);
        }

    }
    private void FixedUpdate()
    {
        
    }
    //private void UpdateTr()
    //{
    //    Vector2 currentPosition = iposition;
    //    Vector2 currentVelocity = ivelocity;
    //    for (int i = 0; i < numDots; i++)
    //    {
    //        traDot[i].transform.position = currentPosition;

    //        currentVelocity += gravity * timeStep;
    //        currentPosition += currentVelocity * timeStep;

    //        traDot[i].SetActive(true);
    //    }
    //}
    void PredictTrajectory(Vector3 startPos, Vector3 vel)
    {
        int step = 60;
        float deltaTime = Time.fixedDeltaTime;
        Vector3 gravity = Physics.gravity;

        Vector3 position = startPos;
        Vector3 velocity = vel;

        for (int i = 0; i < step; i++)
        {
            position += velocity * deltaTime + 0.5f * gravity * deltaTime * deltaTime;
            velocity += gravity * deltaTime;

            _rigidbody2D.velocity = velocity;
            _lineRenderer.SetPosition(i, position);
        }
    }

}
