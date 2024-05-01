using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DotDrawer : MonoBehaviour
{
    public static DotDrawer Instance;

    [SerializeField] private GameObject _dotPrefab;
    [SerializeField] private int _maxDrawDot;
    [SerializeField] private float _dotScale;
    [SerializeField] private GameObject[] _dots;
    [SerializeField] float _dotGap = 0.5f;

    public bool isAllActive = false; // 점들이 켜져있냐?

    public void Awake()
    {
        Instance = this;

        _dots = new GameObject[_maxDrawDot];
        for(int i = 0; i<_maxDrawDot; ++i)
        {
            _dots[i] = Instantiate(_dotPrefab, transform);
            _dots[i].transform.localScale = Vector3.one * _dotScale;

            _dots[i].SetActive(false);
        }
    }

    public void Draw(Vector3 startPos, Vector3 vel)
    {
        int step = _maxDrawDot;
        float deltaTime = _dotGap;
        Vector3 gravity = Physics.gravity;

        Vector3 position = startPos;
        Vector3 velocity = vel;

        for (int i = 0; i < step; i++)
        {
            position -= velocity * deltaTime + 0.5f * gravity * deltaTime * deltaTime;
            velocity -= gravity * deltaTime;

            _dots[i].transform.position = position;
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        if (!isAllActive) return;
        for (int i = 0; i < _maxDrawDot; i++)
        {
            _dots[i].SetActive(false);
        }

        isAllActive = false;
    }

    [ContextMenu("Show")]
    public void Show()
    {
        if (isAllActive) return;
        for (int i = 0; i < _maxDrawDot; i++)
        {
            _dots[i].SetActive(true);
        }

        isAllActive = true;
    }
}
