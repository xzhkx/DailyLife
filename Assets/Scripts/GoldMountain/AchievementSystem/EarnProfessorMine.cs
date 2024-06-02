using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnProfessorMine : MonoBehaviour
{
    public static EarnProfessorMine Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Earn()
    {
        AchievementManager.Instance.EarnAchievement("Mining Professor");
    }
}
