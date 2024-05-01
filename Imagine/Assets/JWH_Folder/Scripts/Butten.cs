using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butten : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject scanObject;
    [SerializeField] private Sprite notP;
    [SerializeField] private Sprite P;
    [SerializeField] private GameObject onTaget;
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
                spriteRenderer.sprite = P;
                onTaget.SetActive(false);
            }
        }
        else
        {
            scanObject = null;
            spriteRenderer.sprite = notP;
            onTaget.SetActive(true);
        }

    }
}
