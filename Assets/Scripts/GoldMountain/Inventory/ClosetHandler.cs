using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetHandler : MonoBehaviour
{
    public static ClosetHandler Instance;

    public GameObject lastOutfit, currentOutfit;

    private void Awake()
    {
        Instance = this;
    }
}
