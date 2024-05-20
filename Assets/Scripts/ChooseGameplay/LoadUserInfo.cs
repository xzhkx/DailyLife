using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadUserInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text userNameText, coinsText;

    private UserInfo currentUser;

    private async void Start()
    {
        currentUser = SaveSystemManager.Instance.LoadUserInfo();

        UserInfo mainUser = await DataAccess.Instance.GetUser(currentUser.Username, currentUser.Password); 

        userNameText.text = mainUser.Username;
        coinsText.text = mainUser.Coins.ToString();


    }
}
