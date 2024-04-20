using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Gotobad : MonoBehaviour
{
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
        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("알ㄴ미루ㅏ미ㅏㅁ우류");
        }*/
    }
    private void FixedUpdate()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos = Camera.main.ScreenToWorldPoint(mousPos);
        movedir = mousPos - transform1.position;
        Vector2 mosp = mousPos - transform1.position;

        

        if (Input.GetButtonDown("Fire1") && isCatch)
        {
            
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
            PredictTrajectory(transform.position, mosp.normalized * speed);

        }
        else
        {
            _rigidbody2D.gravityScale = 1;
            _boxCollider.enabled = true;
            transform.SetParent(null);
        }
        
    }
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

            print(position);
        }
    }

}
