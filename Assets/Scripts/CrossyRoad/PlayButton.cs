using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject jumpDetector;

    private void Awake()
    {
        jumpDetector.SetActive(false);
    }

    public void PlayStart()
    {
        AchievementManager.Instance.EarnAchievement("Gamer...");
        jumpDetector.SetActive(true);
        gameObject.SetActive(false);
    }    
}
