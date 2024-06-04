using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLanturn : MonoBehaviour
{
    public int num;
    Animator fall;
    Animator fall2;
    GameObject LanturnSmash;
    GameObject LanturnSmash2;
    public static bool firstFinish;
    public static bool secondFinish;

    private void Awake()
    {
        fall = GameObject.Find("BigLanturn").GetComponent<Animator>();
        fall2 = GameObject.Find("BigLanturn2").GetComponent<Animator>();
        LanturnSmash = GameObject.Find("HitMeBigLanturn");
        LanturnSmash2 = GameObject.Find("HitMeBigLanturn2");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("cusion"))
        {
            switch(num)
            {
                case 1:
                    fall.SetBool("Fall", true);
                    firstFinish = true;
                    break;
                case 2:
                    fall2.SetBool("Fall", true);
                    secondFinish = true;

                    break;
            }
            LanturnSmash.SetActive(false);
            LanturnSmash2.SetActive(false);
        }
    }
}
