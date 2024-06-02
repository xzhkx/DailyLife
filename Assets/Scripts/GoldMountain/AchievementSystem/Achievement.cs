using UnityEngine;

public class Achievement 
{
    public string description;
    public bool hasEarned;
    public int points;
    private GameObject achievementRef;

    public Achievement(GameObject achievementRef, string description, int points)
    {
        this.achievementRef = achievementRef;
        this.description = description;
        this.points = points;
        hasEarned = false;
    }
}
