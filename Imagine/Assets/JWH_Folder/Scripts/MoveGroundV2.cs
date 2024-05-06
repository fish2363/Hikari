using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundV2 : MonoBehaviour
{
    [SerializeField] private float upDownSpeed = 0.01f;
    private bool wow = false;
    [SerializeField] private Vector2 starttran;
    [SerializeField] private Vector2 maxHigh;
    
    private void Start()
    {
        starttran = transform.position;
    }
    private void FixedUpdate()
    {
        if (wow&& transform.position.y < maxHigh.y) transform.position += Vector3.up * upDownSpeed * Time.deltaTime;
        else if (!wow && starttran.y < transform.position.y)
        {
            transform.position += Vector3.down * upDownSpeed * Time.deltaTime;
        }
        
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&transform.position.y < maxHigh.y)
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
