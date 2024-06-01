using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBarMine : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject bar, barPanel, parentRock;
    [SerializeField] private float mineTime;
    [SerializeField] private int coinsToAdd;
    [SerializeField] private ItemScriptableObject item;

    List<string> itemIDs = new List<string>();

    private string userName;

    private void Awake()
    {
        ResetBar();       
    }

    public async void AnimateBar()
    {
        userName = SaveSystemManager.Instance.LoadUserInfo().Username;
        ItemGM newItem = new ItemGM(userName, item.itemID);
        
        List<ItemGM> items = await DataAccess.Instance.GetAllItems(userName);

        for(int i = 0; i < items.Count; i++)
        {
            itemIDs.Add(items[i].itemID);
        }

        if(!itemIDs.Contains(item.itemID))
        {
            await DataAccess.Instance.AddItem(newItem);
        }

        barPanel.SetActive(true);
        LeanTween.scaleX(bar, 1, mineTime);
    }

    IEnumerator MiningProccess()
    {
        yield return new WaitForSeconds(mineTime);
        ResetBar();
        PlayerMovement.Instance.CanBeMove();
        Debug.Log("Finish");    
        parentRock.SetActive(false);
        CoinsLoad.Instance.SaveCoins(coinsToAdd);
    }

    private void ResetBar()
    {
        barPanel.SetActive(false);
        bar.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
    }

    public void StartInteract()
    {
        PlayerMovement.Instance.NoMove();
        AnimateBar();
        StartCoroutine(MiningProccess());
    }

    public void EndInteract()
    {       
    }
}
