using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollideDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Interactable")) return;

        collider.transform.GetChild(0).gameObject.SetActive(true); 
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Interactable")) return;

        collider.transform.GetChild(0).gameObject.SetActive(false);
    }
}
