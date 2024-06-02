using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaimAchivementButton : MonoBehaviour
{
    public int coins;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Claim);
    }

    private void Claim()
    {
        CoinsLoad.Instance.SaveCoins(coins);
    }
}
