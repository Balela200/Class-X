using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    [Header("Movement System")]
    CharacterController characterController;
    [SerializeField] private float moveSpeed = 5f, runSpeed = 12f;
    private float activeMoveSpeed;
    Vector3 Movement;

    // gravitiy
    public float gravitiyMod = 2.5f;

    [Header("Camera System")]
    [SerializeField] private Transform viewPoint;
    public float mouseSensitivity = 1f;
    private float verticalRotation;
    private Vector2 mouseInput; // Input mouse for look at right and up

    public bool invertLook;

    [Header("Camera System")]
    private Camera cam;

    [Header("UI")]
    public GameObject AddComponentUI;

    [Header("Hant 1")]
    public bool canMove = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        cam = Camera.main;

        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
        CameraPlayer();
        RayPlayer();

        // if Player Input ESC Show the Cursor
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}
        //else if (Cursor.lockState == CursorLockMode.None)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //    }
        //}
    }

    void MovementPlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Run Speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            activeMoveSpeed = runSpeed;
        }
        else
        {
            activeMoveSpeed = moveSpeed;
        }

        float yVel = Movement.y;
        Movement = ((transform.forward * vertical) + (transform.right * horizontal)).normalized * activeMoveSpeed;
        Movement.y = yVel;

        // Add gravity
        Movement.y += Physics.gravity.y * Time.deltaTime * gravitiyMod;

        if(canMove)
        {
            characterController.Move(Movement * Time.deltaTime);
        }
    }

    void CameraPlayer()
    {
        // Input 
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        // Making the player camera move on the Y and X axes
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        verticalRotation += mouseInput.y;
        // Up 60 Dwon -60 
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f);

        if (invertLook)
        {
            viewPoint.rotation = Quaternion.Euler(verticalRotation, viewPoint.rotation.eulerAngles.y, viewPoint.rotation.eulerAngles.z);
        }
        else
        {
            viewPoint.rotation = Quaternion.Euler(-verticalRotation, viewPoint.rotation.eulerAngles.y, viewPoint.rotation.eulerAngles.z);
        }
    }

    void RayPlayer()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        ray.origin = cam.transform.position;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.CompareTag("PC"))
            {
                if(Input.GetKey(KeyCode.E))
                {
                    AddComponentUI.SetActive(true);
                }
            }
        }
    }

    private void LateUpdate()
    {
        // The Camera follw the viewPoint
        cam.transform.position = viewPoint.position;
        cam.transform.rotation = viewPoint.rotation;
    }
}
