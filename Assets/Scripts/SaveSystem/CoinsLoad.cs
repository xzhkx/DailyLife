using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsLoad : MonoBehaviour
{
    public static CoinsLoad Instance;

    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private Button exitButton;

    private int coinsCount;

    private void Awake()
    {
        Instance = this;
        coinsCount = 0;
        coinsText.text = coinsCount.ToString();
        exitButton.onClick.AddListener(SaveCoins);
    }

    public void SaveCoins()
    {

    }

    public void AddCoins(int coinAmount)
    {
        coinsCount += coinAmount;
        coinsText.text = coinsCount.ToString();
    }
}
