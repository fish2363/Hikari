using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance { get; set; }


    public void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("There is two GameManager!");
            Destroy(gameObject);
        }
        instance = this;
    }


}
