using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFile : MonoBehaviour
{
    public Transform transform1;
    private LineRenderer _lineRenderer;
    private Vector3 movedir;
    private void Start()
    {
        _lineRenderer = new LineRenderer();
    }

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
    private void Update()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos = Camera.main.ScreenToWorldPoint(mousPos);
        movedir = mousPos - transform1.position;
        Vector2 mosp = mousPos - transform1.position;
        PredictTrajectory(transform.position, mosp.normalized * 5f);
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
            _lineRenderer.SetPosition(1,position);
        }
    }

}
