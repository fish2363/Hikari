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
    public GameObject trajectoryDotPrefab; // 미리 표시할 점을 위한 프리팹
    public int numberOfDots; // 미리 표시할 점의 개수
    public float dotSpacing; // 점 사이의 간격

    private GameObject[] trajectoryDots; // 미리 표시할 점들을 저장할 배열
    private Vector2 initialPosition; // 물체의 초기 위치
    private Vector2 initialVelocity; // 물체의 초기 속도
    private Vector2 gravity; // 중력 가속도
    private float timeStep; // 시간 간격
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
            // 물체의 초기 위치를 현재 위치로 설정
            initialPosition = transform.position;

            // 마우스 방향으로 힘을 가함
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initialVelocity = mosp.normalized * speed; // 힘의 세기를 조절할 수 있음

            // 궤적 예측을 업데이트
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
        // 초기 위치와 속도를 기반으로 궤적 예측
        Vector2 currentPosition = initialPosition;
        Vector2 currentVelocity = initialVelocity;
        for (int i = 0; i < numberOfDots; i++)
        {
            // 점의 위치 계산
            trajectoryDots[i].transform.position = currentPosition;

            // 다음 위치 및 속도 계산
            currentVelocity += gravity * timeStep;
            currentPosition += currentVelocity * timeStep;

            // 점 활성화
            trajectoryDots[i].SetActive(true);
        }
    }

}
