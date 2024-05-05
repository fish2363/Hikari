using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLanturn : MonoBehaviour
{
    Animator fall;
    GameObject LanturnSmash;

    private void Awake()
    {
        fall = GameObject.Find("BigLanturn").GetComponent<Animator>();
        LanturnSmash = GameObject.Find("HitMeBigLanturn");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("cusion"))
        {
            fall.SetBool("Fall", true);
            LanturnSmash.SetActive(false);
        }
    }
}
