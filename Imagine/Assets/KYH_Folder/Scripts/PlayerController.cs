using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rigid;
    SpriteRenderer Renderer;
    Animator ani;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;
    public bool isLookUp;
    float h;
    public float jump = 5f;
    float v;
    bool isGround;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isGround = true;
            ani.SetBool("Hoit", false);
        }
    }

    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonDown("Horizontal");
        bool vUp = Input.GetButtonDown("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        Debug.Log(h);
        Debug.Log(v);

        //Animation
        ani.SetFloat("hAxisRaw", h);
        ani.SetFloat("vAxisRaw", v);

        if (vDown && v == 1)
        {
            isLookUp = true;
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
            isLookUp = true;
        }
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
            Renderer.flipX = true;
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
            Renderer.flipX = false;
        }
        else if (v == 0)
        {
            isLookUp = false;
        }

        if (Input.GetButtonDown("Fire1") && scanObject != null)
            Debug.Log(scanObject.name);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            ani.SetBool("Hoit", true);
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

            isGround = rigid.gravityScale == 0.5f;
        }
    }

    private void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");

        if (isLookUp == false)
        {
            Vector2 moveVec = isHorizonMove ? new Vector2(h * moveSpeed, rigid.velocity.y) : new Vector2(0, rigid.velocity.y);
            rigid.velocity = moveVec;
        }

        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;

        else
            scanObject = null;

    }


}
