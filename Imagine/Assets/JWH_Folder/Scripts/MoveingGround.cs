using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UIElements;

public class MoveingGround : MonoBehaviour
{
    [SerializeField] private float upDownSpeed = 0.01f;
    private bool wow = false;
    [SerializeField]private Vector2 starttran;
    private void Start()
    {
        starttran = transform.position;
    }
    private void FixedUpdate()
    {
        if(wow) transform.position += Vector3.up * upDownSpeed;
        else if (!wow && starttran.y < transform.position.y)
        {
            transform.position += Vector3.down * upDownSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wow = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wow = false;
        }
    }
}
