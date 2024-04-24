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
    public GameObject trajectoryDotPrefab; // �̸� ǥ���� ���� ���� ������
    public int numberOfDots; // �̸� ǥ���� ���� ����
    public float dotSpacing; // �� ������ ����

    private GameObject[] trajectoryDots; // �̸� ǥ���� ������ ������ �迭
    private Vector2 initialPosition; // ��ü�� �ʱ� ��ġ
    private Vector2 initialVelocity; // ��ü�� �ʱ� �ӵ�
    private Vector2 gravity; // �߷� ���ӵ�
    private float timeStep; // �ð� ����
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        trajectoryDots = new GameObject[numberOfDots];
        gravity = Physics2D.gravity;
        timeStep = Time.fixedDeltaTime;
        for (int i = 0; i < numberOfDots; i++)
        {
            trajectoryDots[i] = Instantiate(trajectoryDotPrefab, transform);
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
            // ��ü�� �ʱ� ��ġ�� ���� ��ġ�� ����
            initialPosition = transform.position;

            // ���콺 �������� ���� ����
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initialVelocity = mosp.normalized * speed; // ���� ���⸦ ������ �� ����

            // ���� ������ ������Ʈ
            UpdateTrajectory();
        }
        

        if (Input.GetMouseButtonUp(0) && isCatch)
        {

            foreach (var dot in trajectoryDots)
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
    private void UpdateTrajectory()
    {
        // �ʱ� ��ġ�� �ӵ��� ������� ���� ����
        Vector2 currentPosition = initialPosition;
        Vector2 currentVelocity = initialVelocity;
        for (int i = 0; i < numberOfDots; i++)
        {
            // ���� ��ġ ���
            trajectoryDots[i].transform.position = currentPosition;

            // ���� ��ġ �� �ӵ� ���
            currentVelocity += gravity * timeStep;
            currentPosition += currentVelocity * timeStep;

            // �� Ȱ��ȭ
            trajectoryDots[i].SetActive(true);
        }
    }

}
