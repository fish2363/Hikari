using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UIElements;

public class MoveingGround : MonoBehaviour
{
    [SerializeField] private float upDownSpeed = 0.01f;
    private bool wow = false;
    private Vector2 starttran;
    [SerializeField] private float maxHigh;
    private bool isTop = false;
    private bool isBottom = false;
    private void Start()
    {
        starttran = transform.position;
    }
    private void FixedUpdate()
    {
        if (transform.position.y < maxHigh && isTop == false&&wow)
        {
            transform.position += new Vector3(0, upDownSpeed, 0);

        }
        else
        {
            isTop = true;
            isBottom = false;
        }
        if (transform.position.y > starttran.y && isBottom == false)
        {
            transform.position += new Vector3(0, -upDownSpeed, 0);
        }
        else
        {
            isBottom = true;
            isTop = false;
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wow = true;
        }
    }
    
}
