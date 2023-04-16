using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;
    private bool isSprinting = false;

    public Transform ground;
    public float distance = 0.3f;

    public float speed;
    public float runSpeed;
    public float jumpHeight;
    public float gravity;

    public LayerMask mask;

    public Canvas Inventory;
    private bool inventoryopen;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Inventory.GetComponent<Canvas>().enabled = false;

    }

    private void Update()
    {
        #region hareket
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        if (isSprinting)
        {
            controller.Move(move * runSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        #endregion

        #region ziplama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        #endregion

        #region yercekimi
        isGrounded = Physics.CheckSphere(ground.position, distance, mask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        velocity.y += Time.deltaTime * gravity;
        controller.Move(velocity * Time.deltaTime);
        #endregion

        #region hizlikos
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
        #endregion

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Inventory.enabled = !Inventory.enabled;

            if (!inventoryopen)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                inventoryopen = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                inventoryopen = false;
            }

        }
    }

}
