using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoSave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StagePlayer pl = collision.GetComponent<StagePlayer>();
            pl.SavePos = transform.position;
        }
    }
}
