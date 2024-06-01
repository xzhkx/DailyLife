using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class GenerateTiles : MonoBehaviour
{
    public static GenerateTiles Instance;

    [Header("Parent")]
    [SerializeField] private Transform parentPanel;
   
    [Header("Tiles")]
    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private int width, length;
    public List<ItemInfo> itemInfoList;

    public Tile[,] tiles;

    [SerializeField] private Button resetButton;

    private void Awake()
    {
        Instance = this;
        resetButton.onClick.AddListener(Reset);
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

    private void Reset()
    {
        StartCoroutine(Pop());
    }

    IEnumerator Pop()
    {
        var deflateSequence = DOTween.Sequence();
        Sequence inflateSequence = DOTween.Sequence();

        for (int x = 1; x <= width; x++)
        {
            for (int y = 1; y <= length; y++)
            {
                Tile currentTile = tiles[x, y];
                deflateSequence.Join(currentTile.GetComponent<RectTransform>()
                        .DOScale(Vector3.zero, 0.3f));
                List<ItemInfo> items = itemInfoList;

                currentTile.itemInfo = items[Random.Range(0, items.Count)];
                currentTile.GetComponent<Image>().sprite = currentTile.itemInfo.sprite;

                inflateSequence.Join(currentTile.GetComponent<RectTransform>()
                    .DOScale(Vector3.one, 0.3f));
            }                       
        }
        yield return deflateSequence.Play().WaitForCompletion();
        yield return inflateSequence.Play().WaitForCompletion();
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
