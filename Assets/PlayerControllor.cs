using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TMP_InputField

public class PlayerControllor : MonoBehaviour
{
    [Header("Movement System")]
    CharacterController characterController;
    [SerializeField] private float moveSpeed = 5f, runSpeed = 12f;
    private float activeMoveSpeed;
    Vector3 Movement;

    // Gravity
    public float gravitiyMod = 2.5f;

    [Header("Camera System")]
    [SerializeField] private Transform viewPoint;
    public float mouseSensitivity = 1f;
    private float verticalRotation;
    private Vector2 mouseInput;

    public bool invertLook;

    private Camera cam;

    [Header("UI")]
    public GameObject AddComponentUI;

    [Header("Hant 1")]
    public bool canMove = false;

    [Header("Input Fields")]
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    void Update()
    {
        CheckInputFields(); // Check the input field values

        // Camera movement is always active
        CameraPlayer();

        // Player movement happens only if `canMove` is true
        if (canMove)
        {
            MovementPlayer();
        }

        RayPlayer();
    }

    void CheckInputFields()
    {
        // Activate canMove if the input fields contain the correct text
        if (inputField1.text == "Horizontal" && inputField2.text == "Vertical")
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    void MovementPlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

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

        Movement.y += Physics.gravity.y * Time.deltaTime * gravitiyMod;

        characterController.Move(Movement * Time.deltaTime);
    }

    void CameraPlayer()
    {
        // Always allow camera movement
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        // Rotate player horizontally with mouse movement
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        // Rotate camera vertically with mouse movement
        verticalRotation += mouseInput.y;
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
            if (hit.collider.CompareTag("PC"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    AddComponentUI.SetActive(true);
                }
            }
        }
    }

    private void LateUpdate()
    {
        cam.transform.position = viewPoint.position;
        cam.transform.rotation = viewPoint.rotation;
    }
}
