using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingGround : MonoBehaviour
{
    [SerializeField] private float upDownSpeed = 0.01f;
    private void FixedUpdate()
    {
        transform.position += Vector3.up * upDownSpeed;
    }
}
