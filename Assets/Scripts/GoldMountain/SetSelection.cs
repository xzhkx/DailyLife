using UnityEngine;

public class SetSelection : MonoBehaviour
{
    private GameObject selection;

    private void Awake()
    {
        selection = transform.GetChild(0).gameObject;
        selection.SetActive(false);
    }

    public void OnSelection()
    {
        IngredientsUI.Instance.lastSelect.transform.GetChild(0).gameObject.SetActive(false);
        selection.SetActive(true);
        IngredientsUI.Instance.lastSelect = gameObject;
    }    
}
