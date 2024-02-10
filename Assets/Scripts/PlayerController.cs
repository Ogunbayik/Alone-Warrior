using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string VERTICAL_INPUT = "Vertical";

    private CharacterController controller;
    private PlayerAnimationController animationController;

    [Header("Player Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform body;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;
    private bool isRun = false;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animationController = GetComponentInChildren<PlayerAnimationController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL_INPUT);
        verticalInput = Input.GetAxis(VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
            isRun = true;
        else
            isRun = false;

        if (isRun)
        {
            controller.Move(movementDirection * movementSpeed * Time.deltaTime);
            animationController.RunAnimation(true);
        }
        else
        {
            animationController.RunAnimation(false);
        }

        HandleRotation();
    }

    private void HandleRotation()
    {
        if (movementDirection != Vector3.zero)
        {
            var rotationY = Quaternion.LookRotation(movementDirection, Vector3.up);
            body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, rotationY, rotationSpeed * Time.deltaTime);
        }
    }


}
