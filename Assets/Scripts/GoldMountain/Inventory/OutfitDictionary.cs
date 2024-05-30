using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class OutfitDictionary : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> outfitUIs, outfitShopGOs;
    [SerializeField]
    private List<ItemScriptableObject> outfits;

    public static OutfitDictionary Instance;

    private Dictionary<string, ItemScriptableObject> OutfitsList = new Dictionary<string, ItemScriptableObject>();
    private Dictionary<string, GameObject> OutfitUseList = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> OutfitGameObjectList = new Dictionary<string, GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < outfits.Count; i++)
        {
            string outfitID = "00" + i.ToString();
            OutfitsList.Add(outfitID, outfits[i]);
            OutfitGameObjectList.Add(outfitID, outfitShopGOs[i]);
            OutfitUseList.Add(outfitID, outfitUIs[i]);
        }

        foreach (GameObject outfit in outfitUIs)
        {
            outfit.SetActive(false);
        }

        UpdateInventory();
    }

    public async void UpdateInventory()
    {
        UserInfo user = SaveSystemManager.Instance.LoadUserInfo();
        List<ItemGM> outfitDatabase = await DataAccess.Instance.GetAllOutfits(user.Username);

        for (int i = 0; i < outfitDatabase.Count; i++)
        {
            string outfitID = outfitDatabase[i].itemID;
            ItemScriptableObject outfit = OutfitsList[outfitID];

            OutfitUseList[outfitID].SetActive(true);
            
            OutfitGameObjectList[outfitID].SetActive(false);
        }
    }
}
