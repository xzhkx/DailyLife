using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject roadParent;
    private bool isGround;

    private Rigidbody playerRigidbody;

    private Vector3 newPos, currentPos;

    private void Start()
    {
        isGround = false;
        playerRigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isGround) return;
         roadParent.transform.position = Vector3.MoveTowards(roadParent.transform.position, newPos, 0.1f);
    }

    public void Jump(Vector3 direction)
    {
        if (isGround) return;

        SoundManager.Instance.PlaySound(SoundType.CLICK, 0.5f);

        currentPos = roadParent.transform.position;
        newPos = roadParent.transform.position + (-1) * direction;
        playerRigidbody.AddForce(Vector3.up * jumpForce);       
        StartCoroutine(JumpTime());
    }

    IEnumerator JumpTime()
    {
        isGround = true;
        yield return new WaitForSeconds(0.5f);
        Debug.Log(Mathf.Abs(currentPos.z) - Mathf.Abs(newPos.z));
        if(Mathf.Abs(currentPos.z) - Mathf.Abs(newPos.z) == -1f)
        {
            CoinsLoad.Instance.SaveCoins(5);
        }      
        isGround = false;
    }   
}
