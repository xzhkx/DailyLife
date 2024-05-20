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

    private CharacterController characterController;
    private PlayerInputActions playerInputActions;

    private void Awake()
    { 
        characterController = GetComponent<CharacterController>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        animator.SetBool("isMove", false);
    }

    private void FixedUpdate()
    {
        Vector2 input = playerInputActions.Player.Movement.ReadValue<Vector2>();

        Vector3 inputConvert = new Vector3(input.x, 0, input.y);

        characterController.Move(inputConvert * runSpeed * Time.fixedDeltaTime);

        if (input == Vector2.zero)
        {
            animator.SetBool("isMove", false);
          
        } else
        {
            animator.SetBool("isMove", true);
            Quaternion toRotation = Quaternion.LookRotation(inputConvert, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,
                rotationSpeed);
        }      
    } 
}
