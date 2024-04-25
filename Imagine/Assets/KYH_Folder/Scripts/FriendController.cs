using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : GameSystem
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
    public float h;
    public float jump = 6f;
    public float v;
    bool isGround;
    Vector2 moveDir;
    Animator BabyAni;
    private bool isDead = false;

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
        if ((collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("cusion")) && collision.contacts[0].normal.y > 0.7f)
        {
            isGround = true;
            KidAni.SetBool("Hoit", false);
        }
        if (collision.gameObject.CompareTag("Magema"))
        {
            isDead = true;
        }
        if (collision.contacts[0].normal.y > 0.7f && collision.gameObject.CompareTag("Tram"))
        {
            rigid.AddForce(Vector2.up * 1.5f * jump, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        if (isDead)
        {
            Time.timeScale = 0;
        }
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        moveDir = manager.isAction ? new Vector2(0, 0) : new Vector2(h, 0);

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
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left; //레이캐스트를 위한 벡터 방향 지정
            switch (playerType)
            {
                case 1:
                    BabyRenderer.flipX = true;
                    break;
                case 2:
                    Debug.Log("Hi");
                    KidRenderer.flipX = true;
                    break;
            }
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
            switch (playerType)
            {
                case 1:
                    BabyRenderer.flipX = false;
                    break;
                case 2:
                    KidRenderer.flipX = false;
                    break;
            }
        }
        else if (v == 0)
        {
            isLookUp = false;
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
