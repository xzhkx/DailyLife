using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateTiles : MonoBehaviour
{
    public static GenerateTiles Instance;

    [Header("Parent")]
    [SerializeField] private Transform parentPanel;

    [SerializeField] private int width, length;

    [Header("Tiles")]
    [SerializeField] private GameObject tilePrefab;
    public List<ItemInfo> itemInfoList;

    public Tile[,] tiles;


    private void Awake()
    {
        Instance = this;

        tiles = new Tile[width+1, length+1];
        Generate();
    }

    public int GetWidth()
    {
        return width;
    }    

    public int GetLength()
    {
        return length;
    }    

    private void Generate()
    {
        for(int x = 1; x <= width; x++)
        {
            for(int y = 1; y <= length; y++)
            {
                GameObject prefab = Instantiate(tilePrefab);
                prefab.GetComponent<RectTransform>().SetParent(parentPanel);

                Tile tile = prefab.GetComponent<Tile>();
                tiles[x, y] = tile;

                tile.itemInfo = itemInfoList[Random.Range(0, itemInfoList.Count)];
                tile.x = x; tile.y = y;

                prefab.GetComponent<Image>().sprite = tile.itemInfo.sprite;
            }    
        }    
    }    
}
