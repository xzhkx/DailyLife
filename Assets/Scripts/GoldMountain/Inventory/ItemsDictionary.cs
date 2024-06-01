using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemsDictionary : MonoBehaviour
{
    public static ItemsDictionary Instance;

    [SerializeField]
    private List<ItemScriptableObject> items;
    [SerializeField]
    private List<GameObject> itemUI, itemGameObjects;
    [SerializeField]
    private TMP_Text collectionText;
    [SerializeField]
    private int maxItems;

    private Dictionary<string, ItemScriptableObject> ItemsList = new Dictionary<string, ItemScriptableObject>(7);
    private Dictionary<string, GameObject> ItemGameObjectList = new Dictionary<string, GameObject>();

    private void Awake()
    {

        Debug.Log(items.Count);
        for (int i = 0; i < items.Count; i++)
        {
            string itemID = "00" + i.ToString();
            Debug.Log(itemID);
            ItemsList.Add(itemID, items[i]);

            if (i >= itemGameObjects.Count) return;
            ItemGameObjectList.Add(itemID, itemGameObjects[i]);
        }

        Instance = this;       
    }

    private void Start()
    {
        for (int i = 0; i < itemUI.Count; i++)
        {
            itemUI[i].SetActive(false);
        }
        UpdateInventory();
    }

    public async void UpdateInventory()
    {
        UserInfo user = SaveSystemManager.Instance.LoadUserInfo();
        List<ItemGM> itemDatabase = await DataAccess.Instance.GetAllItems(user.Username);
        collectionText.text = itemDatabase.Count.ToString() + "/" + maxItems.ToString();

        Debug.Log(itemDatabase.Count);

        for (int i = 0; i < itemDatabase.Count; i++)
        {
            Debug.Log("???");
            string itemID = itemDatabase[i].itemID;
            ItemScriptableObject item = ItemsList[itemID];
            itemUI[i].SetActive(true);
            itemUI[i].GetComponent<Image>().sprite = item.Icon;

            if (!ItemGameObjectList.ContainsKey(itemID)) return;
            ItemGameObjectList[itemID].SetActive(false);
        }   
    }

    public bool ContainItem(GameObject item)
    {
        if (itemGameObjects.Contains(item)) return true;
        else return false;
    }
}
