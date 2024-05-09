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
        transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
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
