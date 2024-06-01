using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDungeonButton : MonoBehaviour
{
    [SerializeField] private string pikaxeID, flashlightID;
    public async void EnterDungeon()
    {
        string name = SaveSystemManager.Instance.LoadUserInfo().Username;
        List<ItemGM> items = await DataAccess.Instance.GetAllItems(name);
        List<string> itemIDs = new List<string>();
        for(int i = 0; i < items.Count; i++)
        {
            itemIDs.Add(items[i].itemID);
        }

        if(itemIDs.Contains(pikaxeID) && itemIDs.Contains(flashlightID))
        {
            SceneManager.LoadScene(6);
        }
    }
}
