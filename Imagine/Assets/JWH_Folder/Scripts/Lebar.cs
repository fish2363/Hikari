using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebar : MonoBehaviour
{
    public static bool isSwOn = false;
    private void Update()
    {
        Debug.Log($" wow!{isSwOn}");
    }
}
