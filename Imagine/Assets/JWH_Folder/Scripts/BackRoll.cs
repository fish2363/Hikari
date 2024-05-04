using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackRoll : MonoBehaviour
{
    private MeshRenderer m_Renderer;
    private float offset = 0;
    private float befortrnsx;
    private float nowtrnsx;
    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }
    
    private void Update()
    {
        
        nowtrnsx = transform.position.x;
        float v = nowtrnsx - befortrnsx;
        offset += v * 0.01f;
        m_Renderer.material.mainTextureOffset = new Vector2(offset, 0);
        befortrnsx = transform.position.x;
    }
}
