using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magemaMove : MonoBehaviour
{
    public float maxHigh;
    public float minHigh;
    private bool  isTop = false;
    private bool isBottom = false;
    private void FixedUpdate()
    {
        if (transform.position.y < maxHigh && isTop==false)
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
            
        }
        else
        {
            isTop = true;
            isBottom = false;
        }
        if (transform.position.y > minHigh && isBottom == false)
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
        }
        else
        {
            isBottom = true;
            isTop = false;
        }
    }
}
