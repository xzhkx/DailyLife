using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpIngredients : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject ingredientSO;

    public async void PickUp()
    {
        string username = SaveSystemManager.Instance.LoadUserInfo().Username;
        IngredientInfo ingredient = new IngredientInfo(username, ingredientSO.itemID);
        await DataAccess.Instance.AddIngredients(ingredient);
    }    
}
