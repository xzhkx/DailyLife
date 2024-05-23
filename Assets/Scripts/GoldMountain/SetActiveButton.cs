using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveButton : MonoBehaviour
{
    [SerializeField] private GameObject objectToSet;

    private void Awake()
    {
        objectToSet.SetActive(false);
    }

    public void SetObject()
    {
        if (objectToSet.activeInHierarchy)
        {
            objectToSet.SetActive(false);
        }
        else objectToSet.SetActive(true);
    }
}
