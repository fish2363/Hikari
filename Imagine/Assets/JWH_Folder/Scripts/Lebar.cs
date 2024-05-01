using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebar : MonoBehaviour
{
    [SerializeField] private GameObject jakdong;
    public  bool isSwOn = false;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isSwOn)
        {
            jakdong.SetActive(false);
            _animator.SetBool("swOn",true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cusion"))
        {
            jakdong.SetActive(false);
            _animator.SetBool("swOn", true);
        }
    }

}
