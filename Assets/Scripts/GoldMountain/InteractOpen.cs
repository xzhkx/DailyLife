using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOpen : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject buttonInteract;
    private GameObject childCollider;

    private void Awake()
    {
        buttonInteract.SetActive(false);
        childCollider = transform.GetChild(0).gameObject;
    }

    public void StartInteract()
    {
        buttonInteract.SetActive(true);
        childCollider.SetActive(true);
    }

    public void EndInteract()
    {
        childCollider.SetActive(false);
        buttonInteract.SetActive(false);
    }
}
