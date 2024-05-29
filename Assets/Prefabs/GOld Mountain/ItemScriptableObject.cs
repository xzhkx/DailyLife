using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create new Item")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemID;
    public string itemName;
    public Sprite Icon;
    public GameObject prefabObj;
}
