using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class SelectedTiles : MonoBehaviour
{
    public static SelectedTiles Instance;

    private List<Tile> selectedTiles = new List<Tile>();
    private List<Tile> neighborTiles = new List<Tile>();
    
    private bool isDoneSelect, isDonePop;
    private int width, length;
      
    private void Awake()
    { 
        Instance = this;
    }

    private void Start()
    {
        isDoneSelect = true;
        isDonePop = true;
        width = GenerateTiles.Instance.GetWidth();
        length = GenerateTiles.Instance.GetLength();
    }

    public void SelectTile(Tile tile)
    {
        if (!isDoneSelect || !isDonePop) return;

        if(!selectedTiles.Contains(tile) && selectedTiles.Count < 2)
        {
            SoundManager.Instance.PlaySound(SoundType.SELECTTILE, 0.5f);
            selectedTiles.Add(tile);
        }    

        if(selectedTiles.Count == 2)
        {
            SoundManager.Instance.PlaySound(SoundType.SELECTTILE, 0.5f);
            AchievementManager.Instance.EarnAchievement("Gamer");
            isDoneSelect = false;
            Tile tile1 = selectedTiles[0];
            Tile tile2 = selectedTiles[1];
            
            StartCoroutine(SwapTile(tile1, tile2));

            selectedTiles.Clear();            
        }
    }    

    IEnumerator SwapTile(Tile tile1, Tile tile2)
    {      
        Transform tile1Transform = tile1.GetComponent<RectTransform>();
        Transform tile2Transform = tile2.GetComponent<RectTransform>();
             
        if (IsNeighbour(tile1, tile2))
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Join(tile1Transform.DOMove(tile2Transform.position, 0.5f))
                .Join(tile2Transform.DOMove(tile1Transform.position, 0.5f));
            yield return sequence.Play().WaitForCompletion();

            Change(ref tile1.itemInfo, ref tile2.itemInfo);

            if (CanPop())
            {
                tile1.GetComponent<Image>().sprite = tile1.itemInfo.sprite;
                tile2.GetComponent<Image>().sprite = tile2.itemInfo.sprite;
                StartCoroutine(Pop());
            } else
            {
                Change(ref tile1.itemInfo, ref tile2.itemInfo);
                tile1Transform = tile1.GetComponent<RectTransform>();
                tile2Transform = tile2.GetComponent<RectTransform>();

                Sequence sequence2 = DOTween.Sequence();
                sequence2.Join(tile1Transform.DOMove(tile2Transform.position, 0.5f))
                    .Join(tile2Transform.DOMove(tile1Transform.position, 0.5f));
                yield return sequence2.Play().WaitForCompletion();             
            }
            isDoneSelect = true;
        }
        else
        {
            isDoneSelect = true;
            yield return null;
        } 
    }     

    private bool CanPop()
    {
        for(int x = 1; x <= width; x++)
        {
            for (int y = 1; y <= length; y++)
            {
                if (GenerateTiles.Instance.tiles[x, y].GetConnectedTiles().Count > 4)
                {                    
                    return true;
                }                   
            }
        }                        
        return false;
    }    

    IEnumerator Pop()
    {
        isDonePop = false;
        for (int x = 1; x <= width; x++)
        {
            for(int y = 1; y <= length; y++)
            {
                SoundManager.Instance.PlaySound(SoundType.CLICK, 0.3f);

                Tile tile = GenerateTiles.Instance.tiles[x, y];
                List<Tile> connectedTiles = tile.GetConnectedTiles();

                if (connectedTiles.Count < 3) continue;

                var deflateSequence = DOTween.Sequence();
                foreach (Tile connectedTile in connectedTiles)
                {
                    deflateSequence.Join(connectedTile.GetComponent<RectTransform>()
                        .DOScale(Vector3.zero, 0.3f));
                }
                yield return deflateSequence.Play().WaitForCompletion();
                
                Sequence inflateSequence = DOTween.Sequence();
                foreach (Tile connectedTile in connectedTiles)
                {
                    List<ItemInfo> items = GenerateTiles.Instance.itemInfoList;

                    connectedTile.itemInfo = items[Random.Range(0, items.Count)];
                    connectedTile.GetComponent<Image>().sprite = connectedTile.itemInfo.sprite;

                    inflateSequence.Join(connectedTile.GetComponent<RectTransform>()
                        .DOScale(Vector3.one, 0.3f));
                }
                yield return inflateSequence.Play().WaitForCompletion();
            }    
        }
        isDonePop = true;
    }    

    private bool IsNeighbour(Tile tile1, Tile tile2)
    {
        int x1 = tile1.x; int y1 = tile1.y;
        int x2 = tile2.x; int y2 = tile2.y;

        if(x1 == x2)
        {
            if(y1 + 1 == y2 || y1 - 1 == y2)
            {
                return true;  
            }    
        } else if(y1 == y2)
        {
            if (x1 + 1 == x2 || x1 - 1 == x2)
            {
                return true;
            }
        }
        return false;
    }    

    private void Change(ref ItemInfo itemInfo1, ref ItemInfo itemInfo2)
    {
        var i = itemInfo1;
        itemInfo1 = itemInfo2;
        itemInfo2 = i;
    }    
}
