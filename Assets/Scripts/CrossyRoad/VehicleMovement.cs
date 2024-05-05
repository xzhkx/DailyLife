using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody carRigidbody;
    private Vector3 originalPos;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>(); 
    }

    private void Start()
    {
        originalPos = new Vector3(-4.5f, 0.25f, transform.parent.position.z);     
    }

    private void FixedUpdate()
    {
        carRigidbody.velocity = Vector3.right * speed;
        Movement();
    }

    private void Movement()
    {      
        if(transform.position.x > 6)
        {
            transform.position = originalPos;
        }    
    }

}
