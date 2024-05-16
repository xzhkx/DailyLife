using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text LoginStateText;
    [SerializeField]
    private TMP_InputField userNameInput, passwordInput;
    [SerializeField]
    private Button loginButton, registerButton;

    private void Awake()
    {
        loginButton.onClick.AddListener(Login);
        registerButton.onClick.AddListener(Register);
    }

    private async void Login()
    {
        string name = userNameInput.text;
        try
        {
            UserInfo user = await DataAccess.Instance.GetUser(name);
            Debug.Log("Login Success!");

        } catch (Exception e) {
            LoginStateText.text = "Wrong Username/Password or account doesn't exist.";
            Debug.Log(e);
        }       
    }    

    private async void Register()
    {
        string name = userNameInput.text;        
        try 
        {
            UserInfo user = await DataAccess.Instance.GetUser(name);
            LoginStateText.text = "Account already existed!";

        } catch(Exception e) {
            await DataAccess.Instance.CreateUser(new UserInfo(name, passwordInput.text));
            Debug.Log("Create Account!");
        }
    }    
}
