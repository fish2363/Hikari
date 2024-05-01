using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebar : MonoBehaviour
{
    [SerializeField] private GameObject jakdong;
    public  bool isSwOn = false;
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
            Animator an = jakdong.GetComponent<Animator>();
            if (!isLeft)
            {
                an.SetBool("open", true);
            }
            else
            {
                an.SetBool("Left", true);
            }
            _animator.SetBool("swOn",true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cusion"))
        {
            Animator an = jakdong.GetComponent<Animator>();
            if (!isLeft)
            {
                an.SetBool("open", true);
            }
            else
            {
                an.SetBool("Left", true);
            }
            _animator.SetBool("swOn", true);
        }
    }

}
