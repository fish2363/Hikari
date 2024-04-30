using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butten : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject scanObject;
    private bool isPress = false;
    [SerializeField] private Sprite notP;
    [SerializeField] private Sprite P;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.up * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.up, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
            if (scanObject.CompareTag("cusion")||scanObject.CompareTag("Player"))
            {
                isPress = true;
                spriteRenderer.sprite = P;
            }
        }
        else
        {
            scanObject = null;
            isPress = false;
            spriteRenderer.sprite = notP;
        }

    }
}
