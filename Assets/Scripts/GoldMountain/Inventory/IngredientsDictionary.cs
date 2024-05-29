using Amazon.Runtime.Internal.Transform;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientsDictionary : MonoBehaviour
{
    public static IngredientsDictionary Instance;

    [SerializeField]
    private List<ItemScriptableObject> ingredientsSO;

    [SerializeField]
    private GameObject itemUI, itemUIContent;
    [SerializeField]
    private TMP_Text collectionText;
    [SerializeField]
    private int maxItems;

    public List<GameObject> itemUIs = new List<GameObject>();
    private Dictionary<string, ItemScriptableObject> ingredientsList = new Dictionary<string, ItemScriptableObject>();   

    private void Awake()
    {
        Instance = this;
        for(int i = 0; i < ingredientsSO.Count; i++)
        {
            ingredientsList.Add(ingredientsSO[i].itemID, ingredientsSO[i]);
        }

        for(int i = 0; i < maxItems; i++)
        {
            GameObject item = Instantiate(itemUI);
            item.SetActive(false);
            item.transform.SetParent(itemUIContent.transform);
            itemUIs.Add(item);
        }
    }

    private void Start()
    {
        UpdateInventory();
    }

    public async void UpdateInventory()
    {
        UserInfo user = SaveSystemManager.Instance.LoadUserInfo();
        List<IngredientInfo> allIngredient = await DataAccess.Instance.GetAllIngredients(user.Username);
        collectionText.text = allIngredient.Count.ToString();
        for(int i = 0; i < allIngredient.Count; i++)
        {
            string ingredientID = allIngredient[i].itemID;

            itemUIs[i].GetComponent<ItemUIInfo>().obj = ingredientsList[ingredientID].prefabObj;
            itemUIs[i].GetComponent<Image>().sprite = ingredientsList[ingredientID].Icon;
            itemUIs[i].SetActive(true);
        }
    }
}
