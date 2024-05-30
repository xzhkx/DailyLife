using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed, rotationSpeed;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private LayerMask layerMask;

    [Header("Stair Handler")]
    [SerializeField]
    private Transform stepRayLower, stepRayUpper;
    [SerializeField]
    private float stepHeight, stepSmooth;

    public static PlayerMovement Instance;
    public bool canMove;
    private PlayerInputActions playerInputActions;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        Instance = this;
        canMove = true;
        playerRigidbody = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        animator.SetBool("isMove", false);

        stepRayUpper.localPosition = new Vector3(stepRayUpper.localPosition.x, stepHeight, stepRayUpper.localPosition.z);
        transform.rotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        HandlerMovement();
        StepClimb();
    } 

    private void StepClimb()
    {
        RaycastHit hitLower;
        if (Physics.Raycast(stepRayLower.position, transform.TransformDirection(Vector3.forward),
            out hitLower, 0.1f, layerMask))            
        {
            RaycastHit hitUpper;
            if(!Physics.Raycast(stepRayUpper.position, transform.TransformDirection(Vector3.forward),
                out hitUpper, 0.2f))
            {
                playerRigidbody.position -= new Vector3(0, -stepSmooth, 0);
            }
        }

        RaycastHit hitLower45;
        if(Physics.Raycast(stepRayLower.position, transform.TransformDirection(1.5f, 0, 1), 
            out hitLower45, 0.1f, layerMask))
        {
            RaycastHit hitUpper45;
            if(!Physics.Raycast(stepRayUpper.position, transform.TransformDirection(1.5f, 0, 1),
                out hitUpper45, 0.2f, layerMask))
            {
                playerRigidbody.position -= new Vector3(0, -stepSmooth, 0);
            }
        }

        RaycastHit hitLowerMinus45;
        if (Physics.Raycast(stepRayLower.position, transform.TransformDirection(1.5f, 0, 1),
            out hitLowerMinus45, 0.1f, layerMask))
        {
            RaycastHit hitUpperMinus45;
            if (!Physics.Raycast(stepRayUpper.position, transform.TransformDirection(1.5f, 0, 1),
                out hitUpperMinus45, 0.2f, layerMask))
            {
                playerRigidbody.position -= new Vector3(0, -stepSmooth, 0);
            }
        }
    }

    private void HandlerMovement()
    {
        Vector2 input = playerInputActions.Player.Movement.ReadValue<Vector2>();

        Vector3 inputConvert = new Vector3(input.x, -0.1f, input.y);

        Vector3 inputConverRotate = new Vector3(input.x, 0f, input.y);

        if (input == Vector2.zero)
        {
            animator.SetBool("isMove", false);
        }
        else
        {
            animator.SetBool("isMove", true);
            playerRigidbody.velocity = inputConvert * runSpeed;
            Quaternion toRotation = Quaternion.LookRotation(inputConverRotate, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,
                rotationSpeed);
        }
    }
}
