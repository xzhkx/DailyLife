using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private bool isGround;

    private Rigidbody playerRigidbody;

    Vector3 currentPos, newPos;

    private void Awake()
    {
        isGround = false;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isGround) return;
        Vector3 currentPos = transform.position;      
        transform.position = Vector3.MoveTowards(currentPos, newPos, 0.5f);       
    }

    public void Jump()
    {
        if (isGround) return;
        newPos = transform.position + new Vector3(0, 0, 1f);
        StartCoroutine(JumpTime());
    }

    IEnumerator JumpTime()
    {
        isGround = true;
        yield return new WaitForSeconds(0.3f);
        isGround = false;
    }    
}
