using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    
    [Range(5, 500)]
    public float sensitivity; // kamera hassaslik ayari
    public Transform body; //player body


    void Start()
    {
        // fare imlecini kapatmak icin
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 inputs = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 rotation = new Vector3(inputs.x, inputs.y, 0f) * sensitivity * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -80f, 90f);
        RotateCamera(this.transform , rotation);
    }

    void RotateCamera(Transform camera, Vector3 rotation) 
    { 
        camera.localRotation = Quaternion.Euler(rotation.y, rotation.x, 0f);
        body.localRotation *= Quaternion.Euler(0f, rotation.x, 0f);
    }
}
