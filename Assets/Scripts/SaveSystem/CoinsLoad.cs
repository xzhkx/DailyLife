using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsLoad : MonoBehaviour
{
    public static CoinsLoad Instance;

    private int currentCoins;
    [SerializeField] private TMP_Text coinsText;

    private UserInfo info;
    private void Awake()
    {
        Instance = this;       
    }

    private async void Start()
    {
        info = SaveSystemManager.Instance.LoadUserInfo();
        int coins = await GetCoins();
        coinsText.text = coins.ToString();
    }

    public async Task<int> GetCoins()
    {
        int coins = await DataAccess.Instance.UpdateCoins(info.Username, info.Password, 0);
        return coins;
    }

    public async void SaveCoins(int coinsToAdd)
    {
        int coins = await DataAccess.Instance.UpdateCoins(info.Username, info.Password, coinsToAdd);
        coinsText.text = coins.ToString();
    }  
}
