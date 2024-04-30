using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    private const float ZoomSpeed = 1.0f; // �ѹ��� �� �Է��� �� �Ǵ� ����
    private const float MinZoomSize = 2.0f; // �ּ� ī�޶� ������
    private const float MaxZoomSize =6.0f;
    private float targetZoomSize;
    public CinemachineVirtualCamera playerCamera;
    public Camera plCamera;

    private void Awake()
    {
        //playerCamera = GetComponent<Camera>();
        targetZoomSize = playerCamera.m_Lens.OrthographicSize;
        plCamera = Camera.main;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControllerZoom();
        UpdateZoom();
    }

    private void ControllerZoom()
    {
        // ���콺 ��ũ�� �Է� �ޱ�
        var scrollInput = Input.GetAxis("Mouse ScrollWheel");
        var hasScrollInput = Mathf.Abs(scrollInput) > Mathf.Epsilon;
        if (!hasScrollInput)
        {
            return;
        }

        // ī�޶� ũ�⸦ ���콺 ��ũ�� �Է¿� ���� �����Ͽ� Ȯ��/���
        var newSize = playerCamera.m_Lens.OrthographicSize - scrollInput * ZoomSpeed;

        // ī�޶� ũ�� ���� �ּҰ��� �ִ밪 ���̷� ����
        targetZoomSize = Mathf.Clamp(newSize, MinZoomSize, MaxZoomSize);
    }

    private void UpdateZoom()
    {
        if (Mathf.Abs(targetZoomSize - playerCamera.m_Lens.OrthographicSize) < Mathf.Epsilon)
        {
            return;
        }

        var mouseWorldPos = plCamera.ScreenToWorldPoint(Input.mousePosition);
        var cameraTransform = transform;
        var currentCameraPosition = cameraTransform.position;
        var offsetCamera = mouseWorldPos - currentCameraPosition - (mouseWorldPos - currentCameraPosition) / (playerCamera.m_Lens.OrthographicSize / targetZoomSize);

        // ī�޶� ũ�� ����
        playerCamera.m_Lens.OrthographicSize = targetZoomSize;

        // �� ������ ���� ī�޶� ��ġ ����
        currentCameraPosition += offsetCamera;
        cameraTransform.position = currentCameraPosition;
    }
}
