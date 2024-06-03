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
        SoundManager.Instance.PlaySound(SoundType.ADDCOIN);
        AchievementManager.Instance.EarnAchievement("Gamer...");
        jumpDetector.SetActive(true);
        gameObject.SetActive(false);
    }    
}
