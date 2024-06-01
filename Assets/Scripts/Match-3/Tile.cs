using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;

    public ItemInfo itemInfo;
    private Button tileButton;

    public Tile Left => x > 1 ? GenerateTiles.Instance.tiles[x - 1, y] : null;
    public Tile Top => y > 1 ? GenerateTiles.Instance.tiles[x, y - 1] : null;
    public Tile Right => x < GenerateTiles.Instance.GetWidth() ? GenerateTiles.Instance.tiles[x + 1, y] : null;
    public Tile Bottom => y < GenerateTiles.Instance.GetLength() ? GenerateTiles.Instance.tiles[x, y + 1] : null;

    public Tile[] Neighbours => new[]
    {
        Left, Top, Right, Bottom
    };

    public Tile(int xIndex, int yIndex)
    {
        x = xIndex; y = yIndex;
    }

    private void Start()
    {
        tileButton = GetComponent<Button>();
        tileButton.onClick.AddListener(SelectTile);
    }

    public List<Tile> GetConnectedTiles(List<Tile> exclude = null)
    {
        List<Tile> result = new List<Tile> { this, };

        if(exclude == null)
        {
            exclude = new List<Tile> { this, };
        } else
        {
            exclude.Add(this);
        }

        foreach(Tile neighbour in Neighbours)
        {
            if (neighbour == null || exclude.Contains(neighbour)
                || neighbour.itemInfo.sprite != itemInfo.sprite) continue;

            result.AddRange(neighbour.GetConnectedTiles(exclude));
        }

        return result;
    }    
    
    private void SelectTile()
    {
        SelectedTiles.Instance.SelectTile(this);
    }        
}
