using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Gotobad : MonoBehaviour
{
    public Transform transform1;
    public GameObject player;
    public bool isCatch = false;
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody2D;
    private Transform plTransform;
    private float speed = 10f;
    private LineRenderer lineRenderer;
    Vector3 movedir;
    public GameObject dotPre;
    public int numDots;
    public float dotSp;

    private GameObject[] traDot;
    private Vector2 iposition;
    private Vector2 ivelocity;
    private Vector2 gravity;
    private float timeStep;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        traDot = new GameObject[numDots];
        gravity = Physics2D.gravity;
        timeStep = Time.fixedDeltaTime;
        for (int i = 0; i < numDots; i++)
        {
            traDot[i] = Instantiate(dotPre, transform);
        }
        plTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        
        Vector3 mousPos = Input.mousePosition;
        mousPos = Camera.main.ScreenToWorldPoint(mousPos);
        movedir = mousPos - transform1.position;
        Vector2 mosp = mousPos - transform1.position;

        if (Input.GetMouseButton(0) && isCatch)
        {
            iposition = transform.position; // 위치 저장

            ivelocity = mosp.normalized * speed; // 힘 주기

            UpdateTr(); // 예측 함수 호출
        }
        

        if (Input.GetMouseButtonUp(0) && isCatch)
        {

            foreach (var dot in traDot)
            {
                dot.SetActive(false);
            }
            Debug.Log("ssss");
            _boxCollider.enabled = true;
            //transform.up = mosp.normalized;
            _rigidbody2D.AddForce(mosp.normalized * speed, ForceMode2D.Impulse);
            isCatch = false;
            
        }


        if (isCatch)
        {
            _rigidbody2D.velocity = new Vector2(0, 0);
            transform.SetParent(transform1);
            transform.position = plTransform.position + new Vector3(0, 2, 0);
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
    private void UpdateTr()
    {
        Vector2 currentPosition = iposition;
        Vector2 currentVelocity = ivelocity;
        for (int i = 0; i < numDots; i++)
        {
            traDot[i].transform.position = currentPosition;

            currentVelocity += gravity * timeStep;
            currentPosition += currentVelocity * timeStep;

            traDot[i].SetActive(true);
        }
    }

}
