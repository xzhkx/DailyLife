using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private GameObject achievePrefab, achieveParent, visualParent, visualAchievement;

    public Dictionary<string, Achievement> achievementCollection = new Dictionary<string, Achievement>();

    private void Start()
    {
        CreateAchievement("Beginner Collector", "Pick up 1 item.", 500);
        CreateAchievement("Advance Collector", "Pick up 5 items.", 1000);
        CreateAchievement("Time for a meal", "Cook 1 ingredient.", 500);
        CreateAchievement("Fabulous Chef", "Cook 10 ingredients.", 2000);
        CreateAchievement("Gamer", "Play Match-3 1 time.", 500);
        CreateAchievement("Gamer...", "Play CrossyRoad 1 time ", 500);
        CreateAchievement("Mining Newbie", "Mine 1 crystal.", 500);
        CreateAchievement("Mining Professor", "Mine 10 crystals.", 2000);
        visualAchievement.SetActive(false);
    }

    private void Update()
    {
    }

    public void EarnAchievement(string title)
    {
        if (achievementCollection[title].HasEarnedAchievement())
        {
            visualAchievement.SetActive(true);
            SetAchievementInfo(visualParent, visualAchievement, title);
            StartCoroutine(HideAchievement(visualAchievement));
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        achievement.SetActive(false);
    }

    public void CreateAchievement(string title, string description, int points)
    {
        GameObject achievement = (GameObject)Instantiate(achievePrefab);

        Achievement newAchievement = new Achievement(achievement, description, points);
        achievementCollection.Add(title, newAchievement);

        SetAchievementInfo(achieveParent, achievement, title);
    }    

    private void SetAchievementInfo(GameObject parent, GameObject achieve, string title)
    {
        Transform achieveTransform = achieve.transform;       
        achieveTransform.SetParent(parent.transform);
        achieveTransform.GetChild(0).GetComponent<TMP_Text>().text = title;
        achieveTransform.GetChild(1).GetComponent<TMP_Text>().text = achievementCollection[title].description;
        achieveTransform.GetChild(3).GetComponent<TMP_Text>().text = achievementCollection[title].points.ToString();
        achieveTransform.localScale = Vector3.one;
    }    
}
