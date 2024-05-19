using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody playerRigidbody;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Movement.performed += MovementPerformed;
    }

    private void FixedUpdate()
    {
        Vector2 input = playerInputActions.Player.Movement.ReadValue<Vector2>();
        playerRigidbody.velocity = new Vector3(input.x, 0, input.y) * speed;
    }

    private void MovementPerformed(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        playerRigidbody.velocity = new Vector3(input.x, 0, input.y) * speed;
    }    
}
