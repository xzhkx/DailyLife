using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    [SerializeField] private List<GameObject> roadTile, grassTile, dirtTile, waterTile;
    [SerializeField] private GameObject roadParent;

    [SerializeField] private int roadAmount;

    public static GenerateRoad Instance;

    private int index;

    private void Awake()
    {
        index = -3;
        Instance = this;
        
        for(int i = 0; i < roadAmount; i++)
        {
            Generate(grassTile, 4);
            Generate(roadTile, 3);
            Generate(waterTile, 4);
            Generate(grassTile, Random.Range(1, grassTile.Count));
            Generate(roadTile, 4);
            Generate(grassTile, 2);
        }    
    }

    private void Generate(List<GameObject> prefabs, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject prefab = prefabs[i];
            GameObject road = Instantiate(prefab, roadParent.transform);
            road.transform.position = new Vector3(0, 0, index);
            index++;
        } 
    }
}
