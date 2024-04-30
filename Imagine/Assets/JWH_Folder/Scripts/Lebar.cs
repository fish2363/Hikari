using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebar : MonoBehaviour
{
    [SerializeField] private GameObject jakdong;
    public  bool isSwOn = false;
    private void Update()
    {
        if (isSwOn)
        {
            jakdong.SetActive(false);
        }
    }
}
