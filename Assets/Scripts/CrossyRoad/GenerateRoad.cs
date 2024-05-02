using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab, roadParent;
    [SerializeField] private int roadAmount;

    public static GenerateRoad Instance;

    public List<GameObject> roads = new List<GameObject>(); 

    private void Awake()
    {
        Instance = this;
        for(int i = 0; i < roadAmount; i++)
        {
            GameObject road = Instantiate(roadPrefab, roadParent.transform);
            road.transform.position = new Vector3(0, 0, i);

            roads.Add(road);
        }    
    }

}
