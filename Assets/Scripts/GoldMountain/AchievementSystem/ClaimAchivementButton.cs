using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClaimAchivementButton : MonoBehaviour
{
    private TMP_Text coinsText;
    public int coins;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Claim);
        coinsText = transform.parent.GetChild(3).gameObject.GetComponent<TMP_Text>();
    }

    private void Claim()
    {
        coinsText.text = "Claimed.";
        CoinsLoad.Instance.SaveCoins(coins);
        gameObject.SetActive(false);
    }
}
