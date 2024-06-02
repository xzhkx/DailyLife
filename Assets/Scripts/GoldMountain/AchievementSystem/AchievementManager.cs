using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    [SerializeField] private GameObject achievePrefab, achieveParent, visualParent, visualAchievement;

    private Dictionary<string, GameObject> achievementUIs = new Dictionary<string, GameObject>();
    public Dictionary<string, Achievement> achievementCollection = new Dictionary<string, Achievement>();

    private string username;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        username = SaveSystemManager.Instance.LoadUserInfo().Username;    

        CreateAchievement("Beginner Collector", "Pick up 1 item.", 500);
        CreateAchievement("Advance Collector", "Pick up 5 items.", 1000);

        CreateAchievement("Road to a Farmer", "Pick up 1 ingredient.", 250);
        CreateAchievement("Time for a meal", "Cook 1 ingredient.", 500);
        CreateAchievement("Fabulous Collector", "Cook 10 ingredients.", 2000);
        CreateAchievement("Legendary Collector", "Cook 50 ingredients.", 20000);
        CreateAchievement("Waster >:(", "Throw away 1 ingredient", 250);

        CreateAchievement("Gamer", "Play Match-3 1 time.", 500);
        CreateAchievement("Gamer...", "Play CrossyRoad 1 time.", 500);

        CreateAchievement("Mining Newbie", "Mine 1 crystal.", 500);
        CreateAchievement("Mining Junior", "Mine 1 Redstone.", 15000);
        CreateAchievement("Mining Professor", "Mine 1 Moonstone.", 30000);
       
        visualAchievement.SetActive(false);
    }

    public async void EarnAchievement(string title)
    {
        try
        {
            AchievementInfo achieve = await DataAccess.Instance.GetAchievement(username, title);

            if (!achieve.hasEarned)
            {
                await DataAccess.Instance.EarnAchievement(username, title);
                visualAchievement.SetActive(true);

                SetAchievementInfo(visualParent, visualAchievement, title);
                UpdateAchievementPanel(title, achievementCollection[title].points);
                StartCoroutine(HideAchievement(visualAchievement));
            }
        } catch
        {

        }       
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(2f);
        achievement.SetActive(false);
    }

    public async void CreateAchievement(string title, string description, int points)
    {
        GameObject achievement = Instantiate(achievePrefab);
        achievementUIs.Add(title, achievement);

        Achievement newAchievement = new Achievement(achievement, description, points);
        achievementCollection.Add(title, newAchievement);

        try
        {
            await DataAccess.Instance.GetAchievement(username, title);
        }
        catch
        {
            await DataAccess.Instance.CreateAchievement(new AchievementInfo(username, title));
        }
        
        SetAchievementInfo(achieveParent, achievement, title);

        AchievementInfo info = await DataAccess.Instance.GetAchievement(username, title);
        if (info.hasEarned)
        {
            achievement.transform.SetParent(null);
            achievement.transform.SetParent(achieveParent.transform);
            achievement.transform.GetChild(3).GetComponent<TMP_Text>().text = "Claimed.";
        }
    }

    private void UpdateAchievementPanel(string title, int points)
    {
        GameObject finishAchieve = achievementUIs[title];
        GameObject achieveChild = finishAchieve.transform.GetChild(5).gameObject;
        Debug.Log(achieveChild.name);
        achieveChild.SetActive(true);
        achieveChild.GetComponent<ClaimAchivementButton>().coins = points;
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
