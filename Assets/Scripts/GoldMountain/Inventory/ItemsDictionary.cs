using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsDictionary : MonoBehaviour
{
    public static ItemsDictionary Instance;

    [SerializeField]
    private List<ItemScriptableObject> items;
    [SerializeField]
    private List<GameObject> itemUI, itemGameObjects;

    private Dictionary<string, ItemScriptableObject> ItemsList = new Dictionary<string, ItemScriptableObject>();
    private Dictionary<string, GameObject> ItemGameObjectList = new Dictionary<string, GameObject>();

    private  void Awake()
    {
        Instance = this;

        for(int i = 1; i <= items.Count; i++)
        {
            string itemID = "00" + i.ToString();
            ItemsList.Add(itemID, items[i - 1]);
            ItemGameObjectList.Add(itemID, itemGameObjects[i - 1]);
        }

        foreach(GameObject item in itemUI)
        {
            item.SetActive(false);
        }
    }

    private void Start()
    {
        UpdateInventory();
    }

    public async void UpdateInventory()
    {
        UserInfo user = SaveSystemManager.Instance.LoadUserInfo();
        List<ItemGM> itemDatabase = await DataAccess.Instance.GetAllItems(user.Username);

        for (int i = 0; i < itemDatabase.Count; i++)
        {
            Debug.Log("!!!");
            string itemID = itemDatabase[i].itemID;
            ItemScriptableObject item = ItemsList[itemID];
            itemUI[i].GetComponent<Image>().sprite = item.Icon;
            itemUI[i].SetActive(true);
            ItemGameObjectList[itemID].SetActive(false);
        }
    }
}
