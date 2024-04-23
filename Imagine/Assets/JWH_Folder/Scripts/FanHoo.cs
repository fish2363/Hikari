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
        if (transform.rotation.y != 0)
        {
            isLeft = false;
        }
    }
    private void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isLeft == true&& _playerController.h < 0)
        {
            _playerController.moveSpeed = 8;
            _playerController.jump = 8;
        }
    }
}
