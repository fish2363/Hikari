using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController pl = collision.GetComponent<PlayerController>();
            pl.savepos = transform.position;
        }
    }
}
