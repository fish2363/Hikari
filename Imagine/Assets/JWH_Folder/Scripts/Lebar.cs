using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebar : MonoBehaviour
{
    [SerializeField] private GameObject jakdong;
    [SerializeField] private GameObject jakdong_2;
    public bool isSwOn = false;
    public bool isLeft = false;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isSwOn)
        {
            if (jakdong != null)
            {
                MoveingWall moveing = jakdong.GetComponent<MoveingWall>();
                moveing.isDongjak = true;
            }
            if (jakdong_2 != null)
            {
                MoveingWall moveing2 = jakdong_2.GetComponent<MoveingWall>();
                moveing2.isDongjak = true;
            }
            _animator.SetBool("swOn",true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cusion"))
        {
            if (jakdong != null)
            {
                MoveingWall moveing = jakdong.GetComponent<MoveingWall>();
                moveing.isDongjak = true;
            }
            if (jakdong_2 != null)
            {
                MoveingWall moveing2 = jakdong_2.GetComponent<MoveingWall>();
                moveing2.isDongjak = true;
            }
            _animator.SetBool("swOn", true);
        }
    }
    public void ResetWow()
    {
        isSwOn = false;
        if (jakdong != null)
        {
            MoveingWall moveing = jakdong.GetComponent<MoveingWall>();
            moveing.isDongjak = false;
        }
        if (jakdong_2 != null)
        {
            MoveingWall moveing2 = jakdong_2.GetComponent<MoveingWall>();
            moveing2.isDongjak = false;
        }
        _animator.SetBool("swOn", false);
    }

}
