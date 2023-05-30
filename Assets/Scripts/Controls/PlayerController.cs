using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : LivingEntity
{
    CharacterController controller;

    public Camera mainCamera;
    public Canvas Inventory;
    public InventoryObject inventory;

    public Transform ground;
    [SerializeField] float distance = 0.3f;
    public LayerMask groundMask;

    [SerializeField] float speed = 5f;
    [SerializeField] float runSpeed = 15f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float gravity = 9.8f;

    bool inventoryopen;
    [SerializeField]bool isGrounded;
    
    Vector2 playerInputs;
    Vector3 velocity;
    
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRadius = 2f;
    [SerializeField] float attackRate = 2f;
    float nextAttackTime;

    public override void Start()
    {
        base.Start();
        controller = GetComponent<CharacterController>();
        Inventory.GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
        Movement();
        Jump();

        // Attacking
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1 / attackRate; // 2 times in 1 sec if rate is 2
            }
        }

        #region Envanter
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Inventory.enabled = !Inventory.enabled;

            if (!inventoryopen)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                inventoryopen = true;
                mainCamera.GetComponent<Camera>().enabled = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                inventoryopen = false;
                mainCamera.GetComponent<Camera>().enabled = true;
            }
        }
        #endregion
    }


    void Movement()
    {
        // Get Inputs
        playerInputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Get Normalized Camera Directions in World Space
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 forwardRelativeVerticalInput = playerInputs.y * cameraForward;
        Vector3 rightRelativeHorizontalInput = playerInputs.x * cameraRight;

        Vector3 cameraRelativeVelocity = (forwardRelativeVerticalInput + rightRelativeHorizontalInput).normalized;

        // Walk - Run
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(cameraRelativeVelocity * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(cameraRelativeVelocity * runSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        // Jump
        isGrounded = Physics.CheckSphere(ground.position, distance, groundMask);

        if (isGrounded && velocity.y <= 0f)
        {
            velocity.y = -2f;
        }

        velocity.y += -gravity * Time.deltaTime;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);
        }

        controller.Move(velocity * Time.deltaTime);
    }

    void Attack()
    {
        Collider[] targets = Physics.OverlapSphere(attackPoint.position, attackRadius);

        foreach (Collider target in targets)
        {
            if (target.GetComponent<LivingEntity>() != null)
            {
                target.GetComponent<LivingEntity>().TakeHit(Random.Range(5f,10f));
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }  
    }

    public void OnTriggerEnter(Collider other)
    {

        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

        //    #region hareket
        //    //float horizontal = Input.GetAxis("Horizontal");
        //    //float vertical = Input.GetAxis("Vertical");

        //    //Vector3 move = transform.right * horizontal + transform.forward * vertical;
        //    //if (isSprinting)
        //    //{
        //    //    controller.Move(move * runSpeed * Time.deltaTime);
        //    //}
        //    //else
        //    //{
        //    //    controller.Move(move * speed * Time.deltaTime);
        //    //}

        //    #endregion

        //    #region ziplama
        //    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //    {
        //        velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        //    }
        //    #endregion

        //    #region yercekimi
        //    isGrounded = Physics.CheckSphere(ground.position, distance, mask);
        //    if (isGrounded && velocity.y < 0)
        //    {
        //        velocity.y = 0f;
        //    }
        //    velocity.y += Time.deltaTime * gravity;
        //    controller.Move(velocity * Time.deltaTime);
        //    #endregion

        //    #region hizlikos
        //    if (Input.GetKeyDown(KeyCode.LeftShift))
        //    {
        //        isSprinting = true;
        //    }
        //    if (Input.GetKeyUp(KeyCode.LeftShift))
        //    {
        //        isSprinting = false;
        //    }
        //    #endregion


    //    #region itemE
 
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        InventoryManager inventoryManager = new InventoryManager();
    //        inventoryManager.add(GetGameObjects());
    //    }


    //    #endregion

    //}

    //private void FixedUpdate()
    //{
        
    //    float horizontal = Input.GetAxisRaw("Horizontal");
    //    float vertical = Input.GetAxisRaw("Vertical");

    //    //Debug.Log(horizontal + "," + vertical);
    //    Vector3 movement = new Vector3(horizontal, 0, vertical);
    //    if (rb != null) Debug.Log("rb is here");

    //    rb.MovePosition(transform.position + movement * Time.fixedDeltaTime * speed);
        
    //}

    //public List<GameObject> colliderList = new List<GameObject>();
    //public void OnTriggerEnter(Collider collider)
    //{
    //    if (!colliderList.Contains(collider.gameObject))
    //    {
    //        colliderList.Add(collider.gameObject);
    //        Debug.Log("Added " + gameObject.name);
    //        Debug.Log("GameObjects in list: " + colliderList.Count);
    //    }
    //}

    //public void OnTriggerExit(Collider collider)
    //{
    //    if (colliderList.Contains(collider.gameObject))
    //    {
    //        colliderList.Remove(collider.gameObject);
    //        Debug.Log("Removed " + gameObject.name);
    //        Debug.Log("GameObjects in list: " + colliderList.Count);
    //    }
    //}

    //List<item> items = new List<item>();
    //public List<item> GetGameObjects()
    //{
    //    for (int i = 0;i< colliderList.Count; i++)
    //    {
    //        items[i]= colliderList[i].GetComponent<item>();
    //    }
    //    return items;
    //}

}