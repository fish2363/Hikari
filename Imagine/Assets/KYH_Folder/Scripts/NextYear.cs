using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextYear : MonoBehaviour
{
    public static bool fadeOut = false;
    public static bool fadeIn = false;
    int year =1;

    // Start is called before the first frame update

    private void Awake()
    {
        fadeOut = GameObject.Find("StartFade").GetComponent<StartFadeIn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(year)
        {
            case 1:
                if (collision.gameObject.CompareTag("Player"))
                {
                    fadeOut = true;
                }
                break;
            case 2:
                if (collision.gameObject.CompareTag("Player"))
                {
                    fadeOut = false;
                    fadeIn = true;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
