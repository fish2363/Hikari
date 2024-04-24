using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanHoo : MonoBehaviour
{
    public bool isLeft = true;
    [SerializeField] private Transform _plTransform;
    private PlayerController _playerController;
    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if (!isLeft)
        {
            transform.Rotate(0, 180, 0);
        }
    }
    private void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;

        if ((isLeft == true && _playerController.h < 0)||(isLeft==false && _playerController.h > 0))
        {
            _playerController.moveSpeed = 5;
        }
        if ((isLeft == true && _playerController.h > 0) || (isLeft == false && _playerController.h < 0))
        {
            _playerController.moveSpeed = 2;
            _playerController.jump = 4;
        }
        if (_playerController.h == 0)
        {
            if (isLeft)
            {
                _plTransform.position += new Vector3(-0.01f, 0, 0);
            }
            else
            {
                _plTransform.position += new Vector3(0.01f, 0, 0);
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerController.moveSpeed = 3;
    }
}
