using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] float mouseSensitivity = 1f;
    [SerializeField] Transform playerBody;
    float xRotation;
    void Start()
    {
        // fare imlecini kapatmak icin
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 cameraInputs = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;
        xRotation = Mathf.Clamp(-cameraInputs.y, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * cameraInputs.x);
    }
}
