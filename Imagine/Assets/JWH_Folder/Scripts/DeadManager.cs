using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadManager : MonoBehaviour
{
    public UnityEvent ResetEvent;
    
    public void Lalalal()
    {
        ResetEvent.Invoke();
    }
}
