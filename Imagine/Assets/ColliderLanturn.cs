using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLanturn : MonoBehaviour
{
    public int num;
    Animator fall;
    Animator fall2;
    GameObject LanturnSmash;

    private void Awake()
    {
        fall = GameObject.Find("BigLanturn").GetComponent<Animator>();
        fall2 = GameObject.Find("BigLanturn2").GetComponent<Animator>();
        LanturnSmash = GameObject.Find("HitMeBigLanturn");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("cusion"))
        {
            switch(num)
            {
                case 1:
                    fall.SetBool("Fall", true);
                    break;
                case 2:
                    fall2.SetBool("Fall", true);
                    break;
            }
            LanturnSmash.SetActive(false);
        }
    }
}
