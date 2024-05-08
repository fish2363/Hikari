using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingWall : MonoBehaviour
{
    public bool isDongjak;
    public bool gazi;
    [SerializeField] private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 starttrns;
    [SerializeField] protected Vector3 endmovetrns;
    
    private void Update()
    {
        if (!isDongjak)
        {
            transform.position = starttrns;
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
