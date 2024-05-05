using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butten : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject scanObject;
    [SerializeField] private Sprite notP;
    [SerializeField] private Sprite P;
    [SerializeField] private GameObject jakdong;
    [SerializeField] private GameObject jakdong_2;
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
                if (jakdong!=null)
                {
                    MoveingWall moveing = jakdong.GetComponent<MoveingWall>();
                    moveing.gazi = false;
                    moveing.isDongjak = true;
                }
                if (jakdong_2 != null)
                {
                    MoveingWall moveing2 = jakdong_2.GetComponent<MoveingWall>();
                    moveing2.gazi = false;
                    moveing2.isDongjak = true;
                }
            }
        }
        else
        {
            scanObject = null;
            spriteRenderer.sprite = notP;
            if (jakdong != null)
            {
                MoveingWall moveing = jakdong.GetComponent<MoveingWall>();
                moveing.gazi = true;
                moveing.isDongjak = false;
            }
            if (jakdong_2!= null)
            {
                MoveingWall moveing2 = jakdong_2.GetComponent<MoveingWall>();
                moveing2.gazi = true;
                moveing2.isDongjak = false;
            }
            
        }

    }
}
