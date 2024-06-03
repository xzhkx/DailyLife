using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveButton : MonoBehaviour
{
    public static SetActiveButton Instance;
    public GameObject objectToSet;
    public bool canBeSet;

    private void Awake()
    {
        canBeSet = false;
        Instance = this;
    }

    public void SetObject()
    {
        if (!canBeSet) return;
        if (objectToSet.activeInHierarchy)
        {
            SoundManager.Instance.PlaySound(SoundType.CLICK);
            PlayerMovement.Instance.CanBeMove();
            if(objectToSet.GetComponentInChildren<PickUpItem>() != null)
            {
                objectToSet.GetComponentInChildren<PickUpItem>().PickUp();
            }           
            else if(objectToSet.GetComponentInChildren<PickUpIngredients>() != null)
            {
                objectToSet.GetComponentInChildren<PickUpIngredients>().PickUp();
            }

            objectToSet.SetActive(false);
            if(ItemsDictionary.Instance != null)
            {
                ItemsDictionary.Instance.UpdateInventory();
            }          
        }
        else
        {
            try
            {
                if (objectToSet != null && !ItemsDictionary.Instance.ContainItem(objectToSet))
                {
                    SoundManager.Instance.PlaySound(SoundType.CLICK);
                    PlayerMovement.Instance.NoMove();
                    objectToSet.SetActive(true);
                    return;
                }
            } catch
            {
                if(objectToSet != null)
                {
                    SoundManager.Instance.PlaySound(SoundType.CLICK);
                    PlayerMovement.Instance.NoMove();
                    objectToSet.SetActive(true);
                }
            }
                 
        }           
    }
}
