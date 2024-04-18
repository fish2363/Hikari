using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Gotobad gotobad;
    public bool badEnter = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            badEnter = true;
            if (collision.gameObject.CompareTag("bad") && Input.GetKeyDown(KeyCode.E))
            {
                
                gotobad = collision.gameObject.GetComponent<Gotobad>();
                gotobad.isCatch = true;
            }
            
        }
    }
    
}
