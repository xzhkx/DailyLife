using UnityEngine;

public class InteractOpen : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject visibleObject;
    private GameObject childCollider;

    private void Start()
    {
        try
        {
            childCollider = transform.GetChild(0).gameObject;
        }
        catch {  }            
    }

    public void StartInteract()
    {
        SetActiveButton.Instance.objectToSet = visibleObject;
        SetActiveButton.Instance.canBeSet = true;
        if (childCollider == null) return;
        childCollider.SetActive(true);       
    }

    public void EndInteract()
    {
        SetActiveButton.Instance.objectToSet = null;
        SetActiveButton.Instance.canBeSet = false;
        if (childCollider == null) return;
        childCollider.SetActive(false);
    }
}
