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
    private Rigidbody2D _Rigidbody2D;
    private Transform plTransform;
    private float speed = 15f;
    private LineRenderer _lineRenderer;
    Vector3 movedir;

    private void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        
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
            
            DotDrawer.Instance.Show();
            DotDrawer.Instance.Draw(transform.position, mosp.normalized * speed);
        }
        

        if (Input.GetMouseButtonUp(0) && isCatch)
        {

            DotDrawer.Instance.Clear();
            
            _boxCollider.enabled = true;
            _Rigidbody2D.AddForce(mosp.normalized * speed, ForceMode2D.Impulse);
            isCatch = false;
            
        }


        if (isCatch)
        {
            _Rigidbody2D.velocity = new Vector2(0, 0);
            transform.SetParent(plTransform);
            transform.position = plTransform.position + new Vector3(0, 0.5f, 0);
            _Rigidbody2D.gravityScale = 0;
            _boxCollider.enabled = false;
            

        }
        else
        {
            _Rigidbody2D.gravityScale = 1;
            _boxCollider.enabled = true;
            transform.SetParent(null);
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tram"))
        {
            _Rigidbody2D.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
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

            _Rigidbody2D.velocity = velocity;
            _lineRenderer.SetPosition(i, position);
        }
    }

}
