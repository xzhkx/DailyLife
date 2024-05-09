using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetect : MonoBehaviour
{
    private Transform parent;
    private void Awake()
    {
        parent = GetComponentInParent<Transform>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Wood")) return;

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Wood")) return;

        
    }
}
