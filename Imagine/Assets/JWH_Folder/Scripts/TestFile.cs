using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFile : MonoBehaviour
{
    public GameObject trajectoryDotPrefab; // �̸� ǥ���� ���� ���� ������
    public int numberOfDots; // �̸� ǥ���� ���� ����
    public float dotSpacing; // �� ������ ����

    private GameObject[] trajectoryDots; // �̸� ǥ���� ������ ������ �迭
    private Vector2 initialPosition; // ��ü�� �ʱ� ��ġ
    private Vector2 initialVelocity; // ��ü�� �ʱ� �ӵ�
    private Vector2 gravity; // �߷� ���ӵ�
    private float timeStep; // �ð� ����
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
            // ��ü�� �ʱ� ��ġ�� ���� ��ġ�� ����
            initialPosition = transform.position;

            // ���콺 �������� ���� ����
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initialVelocity = (mousePosition - initialPosition).normalized * 10f; // ���� ���⸦ ������ �� ����

            // ���� ������ ������Ʈ
            UpdateTrajectory();
        }
        //else
        //{
        //    // ���콺�� ������ ������ ��� ������ ��Ȱ��ȭ
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
