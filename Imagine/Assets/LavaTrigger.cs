using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour
{
    Animator lavaOn;
    GameObject warning;
    GameObject lava;

    private void Awake()
    {
        lavaOn = GameObject.Find("Lava").GetComponent<Animator>();
        warning = GameObject.Find("WarningImage");
        lava = GameObject.Find("Lava");
    }

    private void Start()
    {
        warning.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Warning"))
        {
            StartCoroutine(WarningCount());
        }
    }

    IEnumerator WarningCount()
    {
        warning.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        lavaOn.SetBool("LavaUp", true);
        warning.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        lavaOn.SetBool("LavaUp", false);
        gameObject.SetActive(false);
    }
}
