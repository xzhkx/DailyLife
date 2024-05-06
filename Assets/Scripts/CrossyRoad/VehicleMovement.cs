using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody carRigidbody;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();        
    }

    private void FixedUpdate()
    {
        carRigidbody.velocity = Vector3.right * speed;
        Movement();
    }

    private void Movement()
    {      
        if(transform.position.x > 6.5f)
        {
            transform.position = new Vector3(-9f, 0.25f, transform.parent.position.z); 
        }    
    }
}
