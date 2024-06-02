using System.Collections;
using UnityEngine;
using DentedPixel;

public class LoadBar : MonoBehaviour
{
    [SerializeField] private GameObject barPanel, bar, cookPanel;
    [SerializeField] private int loadTime, cookedCoins, throwCoins;
    private string username;

    private void Start()
    {
        ResetBar();
        username = SaveSystemManager.Instance.LoadUserInfo().Username;
    }

    public void ThrowAway()
    {
        GameObject food = IngredientsUI.Instance.currentSelect;
        if (food == null) return;

        Destroy(food);
        DataAccess.Instance.DeleteIngredient
            (IngredientsUI.Instance.lastSelect.GetComponent<ItemUIInfo>().itemID, username);
        IngredientsDictionary.Instance.UpdateInventory();

        AchievementManager.Instance.EarnAchievement("Waster >:(");
        CoinsLoad.Instance.SaveCoins(throwCoins);
    }

    public void AnimateBar()
    {
        GameObject food = IngredientsUI.Instance.currentSelect;

        if (food == null) return;

        Destroy(food);
        DataAccess.Instance.DeleteIngredient
            (IngredientsUI.Instance.lastSelect.GetComponent<ItemUIInfo>().itemID, username);
        IngredientsDictionary.Instance.UpdateInventory();

        barPanel.SetActive(true);
        cookPanel.SetActive(false);

        PlayerMovement.Instance.CanBeMove();

        bar.GetComponent<RectTransform>().localScale = new Vector3(0, 0.7f, 1);
        LeanTween.scaleX(bar, 1, loadTime);

        StartCoroutine(CookingProccess());
    }

    IEnumerator CookingProccess()
    {
        yield return new WaitForSeconds(loadTime);
        ResetBar();
        AchievementManager.Instance.EarnAchievement("Time for a meal");
    }

    private void ResetBar()
    {
        barPanel.SetActive(false);
        bar.GetComponent<RectTransform>().localScale = new Vector3(0, 0.7f, 1);
        CoinsLoad.Instance.SaveCoins(cookedCoins);
    }
}
