using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameSystem
{
    public float moveSpeed;
    Rigidbody2D rigid;
    SpriteRenderer KidRenderer;
    SpriteRenderer BabyRenderer;
    Animator KidAni;
    public GameManager manager;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;
    public bool isLookUp;
    float h;
    public float jump = 5f;
    float v;
    bool isGround;
    Vector2 moveDir;
    Animator BabyAni;

    bool currentFlip = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        KidAni = GameObject.Find("kidSprite").GetComponent<Animator>();
        BabyAni = GameObject.Find("BabySprite").GetComponent<Animator>();
        KidRenderer = GameObject.Find("kidSprite").GetComponent<SpriteRenderer>();
        BabyRenderer = GameObject.Find("BabySprite").GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isGround = true;
            KidAni.SetBool("Hoit", false);
        }
    }

    void Update()
    {

        float h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        float v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        moveDir = manager.isAction ? new Vector2(0,0) : new Vector2(h, 0);

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonDown("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        if (vDown && v == 1)
        {
            isLookUp = true;
            Debug.Log("됨");
        }
        else if (vDown && v == -1)
        { 
            isLookUp = true;
        }
        else if (hDown)
        {
        }
        else if (v == 0)
        {
            isLookUp = false;
        }
        if (h == -1)
        {
            if (currentFlip != true)
            {
                currentFlip = true;
                dirVec = Vector3.left; //레이캐스트를 위한 벡터 방향 지정
                Flip(currentFlip);
            }
        }
        else if (h == 1)
        {
            if (currentFlip != false)
            {
                currentFlip = false;
                dirVec = Vector3.right;
                Flip(currentFlip);
            }
        }

        if (Input.GetButtonDown("Fire1") && scanObject != null)
        {
            manager.Action(scanObject);
        }
            

        //Animation
        if (Input.GetButtonDown("Jump") && isGround && playerType == 2)
        {

            KidAni.SetBool("Hoit", Input.GetButtonDown("Jump") && isGround);
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

            isGround = rigid.gravityScale == 0.5f;
        }
        else
        {
            switch (playerType)
            {
                case 1:
                    BabyAni.SetBool("Walk", moveDir.magnitude > 0);
                    break;
                case 2:
                    KidAni.SetBool("Walk", moveDir.magnitude > 0);

                    KidAni.SetFloat("vAxisRaw", v);
                    break;
            }
        }
    }

    private void Flip(bool value)
    {
        switch (playerType)
        {
            case 1:
                BabyRenderer.flipX = value;
                break;
            case 2:
                KidRenderer.flipX = value;
                break;
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
