using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyOutfitButton : MonoBehaviour
{
    [SerializeField] private int outfitPrice;
    [SerializeField] private ItemScriptableObject outfit;

    public async void Buy()
    {
        int coins = await CoinsLoad.Instance.GetCoins();
        if(coins - outfitPrice >= 0)
        {
            SoundManager.Instance.PlaySound(SoundType.CLAIM);
            string name = SaveSystemManager.Instance.LoadUserInfo().Username;
            ItemGM outfitItem = new ItemGM(name, outfit.itemID);
            await DataAccess.Instance.AddOutfit(outfitItem);
            CoinsLoad.Instance.SaveCoins(-outfitPrice);
            OutfitDictionary.Instance.UpdateInventory();
        }
    }
}
