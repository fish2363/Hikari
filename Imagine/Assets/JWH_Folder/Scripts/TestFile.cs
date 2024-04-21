using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFile : MonoBehaviour
{
    public GameObject trajectoryDotPrefab; // 미리 표시할 점을 위한 프리팹
    public int numberOfDots; // 미리 표시할 점의 개수
    public float dotSpacing; // 점 사이의 간격

    private GameObject[] trajectoryDots; // 미리 표시할 점들을 저장할 배열
    private Vector2 initialPosition; // 물체의 초기 위치
    private Vector2 initialVelocity; // 물체의 초기 속도
    private Vector2 gravity; // 중력 가속도
    private float timeStep; // 시간 간격
    #region
    //[SerializeField] float _InitalVel;
    //[SerializeField] float _Angle;
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        float angle = _Angle * Mathf.Deg2Rad;
    //        StopAllCoroutines();
    //        StartCoroutine(Test_Para(_InitalVel, angle));
    //    }
    //}
    //IEnumerator Test_Para(float v0, float angle)
    //{
    //    float t = 0;
    //    while (t < 100)
    //    {
    //        float x = v0 * t * Mathf.Cos(angle);
    //        float y = v0 * t * Mathf.Sin(angle) - (1f / 2f) * Physics.gravity.y * Mathf.Pow(t, 2);
    //        transform.position = new Vector3(x, y, 0);

    //        t += Time.deltaTime;
    //        yield return null;
    //    }
    //}
    #endregion

    private void Start()
    {
        trajectoryDots = new GameObject[numberOfDots];
        gravity = Physics2D.gravity;
        timeStep = Time.fixedDeltaTime;
        for (int i = 0; i < numberOfDots; i++)
        {
            trajectoryDots[i] = Instantiate(trajectoryDotPrefab, transform);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 물체의 초기 위치를 현재 위치로 설정
            initialPosition = transform.position;

            // 마우스 방향으로 힘을 가함
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initialVelocity = (mousePosition - initialPosition).normalized * 10f; // 힘의 세기를 조절할 수 있음

            // 궤적 예측을 업데이트
            UpdateTrajectory();
        }
        //else
        //{
        //    // 마우스를 누르지 않으면 모든 점들을 비활성화
        //    foreach (var dot in trajectoryDots)
        //    {
        //        dot.SetActive(false);
        //    }
        //}
        //foreach (var dot in trajectoryDots)
        //{
        //    dot.SetActive(false);
        //}

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
