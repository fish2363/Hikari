using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLanturn : MonoBehaviour
{
    Animator fall;

    private void Awake()
    {
        fall = GameObject.Find("BigLanturn").GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("cusion"))
        {
            fall.SetBool("Fall", true);
        }
    }
}
