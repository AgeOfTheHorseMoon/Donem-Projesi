using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    [Range(5, 500)]
    public float sensitivity; // kamera hassaslik ayari
    public Transform target; // objeyi takip etmesi icin

    private float rotationX = 0.0f; 
    private float rotationY = 0.0f;


    void Start()
    {
        // fare imlecini kapatmak icin
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // farenin aldigi rotasyonlara gore x ve y ekseninden kamera acilari alma
        rotationX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -80.0f, 90.0f); // bakis acisini sinirlama


        if (target != null)
        {
            // Rotate the character based on the camera rotation around the Y axis
            target.rotation = Quaternion.Euler(0, rotationX, 0);

            // Rotate the target based on the camera rotation around the X axis
            target.localRotation *= Quaternion.Euler(-rotationY, 0, 0);
        }



    }
}
