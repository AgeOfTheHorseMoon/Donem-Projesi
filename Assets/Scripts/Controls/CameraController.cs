using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] float mouseSensitivity = 1f;
    [SerializeField] Transform playerBody;
    
    float cameraVerticalRotation;

    void Start()
    {
        // fare imlecini kapatmak icin
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        Vector2 cameraInputs = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;

        cameraVerticalRotation -= cameraInputs.y;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

        // Debug.Log(cameraVerticalRotation + " -> " + cameraInputs );

        transform.localRotation = Quaternion.Euler(cameraVerticalRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * cameraInputs.x);
    }
}
