using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOpen : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject visibleObject;
    private GameObject childCollider;

    private void Awake()
    {        
        childCollider = transform.GetChild(0).gameObject;
    }

    public void StartInteract()
    {
        SetActiveButton.Instance.objectToSet = visibleObject;
        SetActiveButton.Instance.canBeSet = true;
        childCollider.SetActive(true);
    }

    public void EndInteract()
    {
        SetActiveButton.Instance.canBeSet = false;
        childCollider.SetActive(false);
    }
}
