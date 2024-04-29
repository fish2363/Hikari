using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SpriteSystem, IControllerPhysics
{
    Rigidbody2D rigid;
    SpriteRenderer KidRenderer;
    SpriteRenderer BabyRenderer;
    Animator KidAni;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;
    public bool isLookUp;
    public float v;
    Vector2 moveDir;
    Animator BabyAni;
    private bool isDead = false;
    FriendController friendControll;


    public bool isCollisionStay { get; set; } = false;
    [field: SerializeField] public float moveSpeed { get; set; } = 3;
    [field: SerializeField] public float jump { get; set; } = 6;
    [field: SerializeField] public float h { get; set; }
    public Transform trm => transform;
    [field: SerializeField] public bool isGround { get; set; }

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
        h = GameManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = GameManager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        moveDir = GameManager.isAction ? new Vector2(0, 0) : new Vector2(h, 0);

        bool hDown = GameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = GameManager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = GameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vUp = GameManager.isAction ? false : Input.GetButtonDown("Vertical");

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

        if (Input.GetButtonDown("Fire1"))
        {
            print("뙛어용");
            isHorizonMove = false;
            h = 0;

            KidAni.SetBool("Walk", false);

            GameObject.Find("Friend").GetComponent<FriendController>().enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = false;
        }

        if (GameManager.stopAni == 1)
        {
            KidAni.SetBool("Stop", false);
            if (moveSpeed == 0)
            {
                moveSpeed = 3;
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
        else
        {
            KidAni.SetBool("Stop", GameManager.stopAni == 2);
            moveSpeed = 0;
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