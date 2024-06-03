using UnityEngine;

public class PickUpIngredients : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject ingredientSO;

    public async void PickUp()
    {
        string username = SaveSystemManager.Instance.LoadUserInfo().Username;
        IngredientInfo ingredient = new IngredientInfo(username, ingredientSO.itemID);
        Destroy(transform.parent.gameObject);
        await DataAccess.Instance.AddIngredients(ingredient);
        AchievementManager.Instance.EarnAchievement("Road to a Farmer");
    }    
}
