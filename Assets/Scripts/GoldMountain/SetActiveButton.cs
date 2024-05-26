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
            objectToSet.SetActive(false);
        }
        else objectToSet.SetActive(true);
    }
}
