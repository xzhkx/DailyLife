using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject itemScriptableObject;

    public async void PickUp()
    {
        string username = SaveSystemManager.Instance.LoadUserInfo().Username;
        ItemGM item = new ItemGM(username, itemScriptableObject.itemID);
        await DataAccess.Instance.AddItem(item);        
    }  
}
