using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsUI : MonoBehaviour
{
    public static IngredientsUI Instance;
    public GameObject lastSelect;

    public GameObject currentSelect;

    [SerializeField] private Transform holdPos;

    private void Awake()
    {
        Instance = this;       
    }

    private void Start()
    {
        lastSelect = IngredientsDictionary.Instance.itemUIs[0];
        lastSelect.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ConfirmSelectObj()
    {
        if (currentSelect != null) return;

        GameObject food = Instantiate(lastSelect.GetComponent<ItemUIInfo>().obj);
        currentSelect = food;

        food.SetActive(true);
        food.transform.position = holdPos.position;
        food.transform.SetParent(holdPos);
    }
}
