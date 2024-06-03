using UnityEngine;

public class SetActiveGO : MonoBehaviour
{
    [SerializeField] private GameObject objToSet;

    private void Start()
    {
        objToSet.SetActive(false);
    }

    public void SetActive()
    {
        SoundManager.Instance.PlaySound(SoundType.CLICK);
        if (objToSet.activeInHierarchy)
        {
            objToSet.SetActive(false);
        } else objToSet.SetActive(true);
    }
}
