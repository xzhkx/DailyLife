using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private bool isGround;

    private Rigidbody playerRigidbody;
    int i;

    Vector3 currentPos, newPos;

    private void Awake()
    {
        i = 0;
        isGround = false;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isGround) return;
        Vector3 currentPos = transform.position;
        newPos = GenerateRoad.Instance.roads[i].transform.position;
        transform.position = Vector3.MoveTowards(currentPos, newPos, 0.5f);       
    }

    public void Jump()
    {
        if (isGround) return;
        i++;
        StartCoroutine(JumpTime());
    }

    IEnumerator JumpTime()
    {
        isGround = true;
        yield return new WaitForSeconds(0.3f);
        isGround = false;
    }    
}
