using UnityEngine;

public class UseOutfit : MonoBehaviour
{
    [SerializeField] private GameObject outfit;

    public void Use()
    {
        if (ClosetHandler.Instance.lastOutfit == null && ClosetHandler.Instance.currentOutfit == null)
        {
            ClosetHandler.Instance.lastOutfit = outfit;
            outfit.SetActive(true);

        } else if (ClosetHandler.Instance.lastOutfit != null)
        {
            ClosetHandler.Instance.lastOutfit.SetActive(false);
            ClosetHandler.Instance.lastOutfit = outfit;
            outfit.SetActive(true);
        }
    }
}
