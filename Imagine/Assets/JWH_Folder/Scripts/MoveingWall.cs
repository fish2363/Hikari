using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingWall : MonoBehaviour
{
    public bool isReset;
    public bool isDongjak;
    public bool gazi;
    AudioSource open;
    [SerializeField] private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 starttrns;
    [SerializeField] protected Vector3 endmovetrns;

    private void Awake()
    {
        open = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(isDongjak)
        {
            open.Play();
        }

        if (isReset)
        {
            transform.position = starttrns;
            isReset = false;
        }

        if (dir.y > 0)
        {
            if (transform.position.y < endmovetrns.y && isDongjak)
            {
                transform.position += dir * speed * Time.deltaTime;
            }
            if (gazi && transform.position.y > starttrns.y)
            {
                transform.position -= dir * speed * Time.deltaTime;
            }
        }
        if (dir.y < 0)
        {
            if (transform.position.y > endmovetrns.y && isDongjak)
            {
                transform.position += dir * speed * Time.deltaTime;
            }
            if (gazi && transform.position.y < starttrns.y)
            {
                transform.position -= dir * speed * Time.deltaTime;
            }
        }
        if (dir.x > 0)
        {
            if (transform.position.x < endmovetrns.x && isDongjak)
            {
                transform.position += dir * speed * Time.deltaTime;
            }
            if (gazi && transform.position.x > starttrns.x)
            {
                transform.position -= dir * speed * Time.deltaTime;
            }
        }
        if (dir.x < 0)
        {
            if (transform.position.x > endmovetrns.x && isDongjak)
            {
                transform.position += dir * speed * Time.deltaTime;
            }
            if (gazi && transform.position.x < starttrns.x)
            {
                transform.position -= dir * speed * Time.deltaTime;
            }
        }



    }

}
