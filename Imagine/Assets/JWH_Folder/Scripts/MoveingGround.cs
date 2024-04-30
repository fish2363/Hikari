using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingGround : MonoBehaviour
{
    [SerializeField] private float upDownSpeed = 0.01f;
    private bool wow = false;
    private void FixedUpdate()
    {
        if(wow) transform.position += Vector3.up * upDownSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wow = true;
        }
    }
}
