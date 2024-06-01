using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement 
{
    public string description;
    private bool isUnlocked;
    public int points;
    private GameObject achievementRef;

    public Achievement(GameObject achievementRef, string description, int points)
    {
        this.achievementRef = achievementRef;
        this.description = description;
        this.points = points;
        isUnlocked = false;
    }

    public bool HasEarnedAchievement()
    {
        if (!isUnlocked)
        {
            isUnlocked = true;
            return true;
        }
        else return false;
    }
}
