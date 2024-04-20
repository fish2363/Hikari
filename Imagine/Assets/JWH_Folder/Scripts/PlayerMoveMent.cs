using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;

public class PlayerMoveMent : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private Interaction interaction;
    private bool isJumping = true;
    private Rigidbody2D rigid;
    private Gotobad gotobad;
    private void Awake()
    {
        
        interaction = GetComponentInChildren<Interaction>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 movedir = new Vector3(x, 0, 0);
        transform.position += movedir.normalized * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && isJumping==false)
        {
            rigid.AddForce(Vector3.up * jumpPower , ForceMode2D.Impulse);
            isJumping = true;
        }
        
        //if (Input.GetKeyDown(KeyCode.E)&&interaction.badEnter==true)
        //{
        //    Debug.Log("Àâ¾Ò¾î");
            
        //}
        
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider != null)
        {
            if (rayHit.distance < 0.6f && rigid.velocity.y < 0)
                isJumping = false;

        }
    }

    

}