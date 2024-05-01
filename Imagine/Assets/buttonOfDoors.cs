using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOfDoors : MonoBehaviour
{
    private SpriteRenderer push;
    public Animator open;
    public GameObject setActive;
    public string action;
    SpriteRenderer pushButton;
    SpriteRenderer notPushButton;

    private void Awake()
    {
        push = gameObject.GetComponent<SpriteRenderer>();
        pushButton = GameObject.Find("PushButton").GetComponent<SpriteRenderer>();
        notPushButton = GameObject.Find("NotPushButton").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            push.sprite = pushButton.sprite;
            switch(action)
            {
                case "setActive":
                    setActive.SetActive(false);
                    break;
                case "anima":
                    open.SetBool("open", true);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            push.sprite = notPushButton.sprite;
            switch (action)
            {
                case "setActive":
                    setActive.SetActive(true);
                    break;
                case "anima":
                    open.SetBool("open", false);
                    break;
            }
        }
    }
}
