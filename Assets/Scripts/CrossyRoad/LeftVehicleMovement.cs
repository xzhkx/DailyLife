using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftVehicleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody carRigidbody;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        carRigidbody.velocity = Vector3.left * speed;
        Movement();
    }

    private void Movement()
    {
        if (transform.position.x < -6.5f)
        {
            transform.position = new Vector3(8f, 0.25f, transform.parent.position.z);
        }
    }
}
