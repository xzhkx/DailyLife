using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollideDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Interactable")) return;
        
        collider.GetComponent<IInteractable>().StartInteract();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Interactable")) return;

        collider.GetComponent<IInteractable>().EndInteract();
    }
}
