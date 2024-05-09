using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPadMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody woodRigidbody;

    private void Awake()
    {
        woodRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        woodRigidbody.velocity = Vector3.forward * speed;
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
