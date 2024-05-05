using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    [SerializeField] private GameObject roadTile, grassTile, dirtTile, waterTile, roadParent;
    [SerializeField] private int roadAmount;

    public static GenerateRoad Instance;

    private int index;

    private void Awake()
    {
        index = -4;
        Instance = this;

        for(int k = 0; k <= 4; k++)
        {
            GameObject grass = Instantiate(grassTile, roadParent.transform);
            grass.transform.position = new Vector3(0, 0, index);
            index++;
        }    
        
        for(int i = 0; i < roadAmount; i++)
        {
            for(int a = 0; a < 4; a++)
            {
                GameObject water = Instantiate(waterTile, roadParent.transform);
                water.transform.position = new Vector3(0, 0, index);
                index++;
            }    
            
            GameObject grass = Instantiate(grassTile, roadParent.transform);
            grass.transform.position = new Vector3(0, 0, index);
            index++;

            for (int a = 0; a < 2; a++)
            {
                GameObject road = Instantiate(roadTile, roadParent.transform);
                road.transform.position = new Vector3(0, 0, index);
                index++;
            }
        }    
    }
}
