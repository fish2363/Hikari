using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingWall : MonoBehaviour
{
    [SerializeField] public bool isDongjak;
    [SerializeField] private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] protected Vector3 endmovetrns;
    
    private void Update()
    {
        if (dir.y > 0)
        {
            if (transform.position.y < endmovetrns.y && isDongjak)
            {
                transform.position += dir * speed;
            }
        }
        if (dir.y < 0)
        {
            if (transform.position.y > endmovetrns.y && isDongjak)
            {
                transform.position += dir * speed;
            }
        }
        if (dir.x > 0)
        {
            if (transform.position.x < endmovetrns.x && isDongjak)
            {
                transform.position += dir * speed;
            }
        }
        if (dir.x < 0)
        {
            if (transform.position.x > endmovetrns.x && isDongjak)
            {
                transform.position += dir * speed;
            }
        }



    }

}
