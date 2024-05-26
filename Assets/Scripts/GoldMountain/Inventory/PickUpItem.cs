using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemScriptableObject itemScriptableObject;

    public async void StartInteract()
    {
        string username = SaveSystemManager.Instance.LoadUserInfo().Username;
        ItemGM item = new ItemGM(username, itemScriptableObject.itemID);
        await DataAccess.Instance.AddItem(item);
        ItemsDictionary.Instance.UpdateInventory();
    }
    public void EndInteract()
    {
        gameObject.SetActive(false);
    }  
}
