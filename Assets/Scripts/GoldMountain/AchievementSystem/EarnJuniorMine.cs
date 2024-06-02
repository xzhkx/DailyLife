using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnJuniorMine : MonoBehaviour
{
    public static EarnJuniorMine Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Earn()
    {
        AchievementManager.Instance.EarnAchievement("Mining Junior");
    }
}
