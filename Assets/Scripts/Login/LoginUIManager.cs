using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginUIManager : MonoBehaviour
{
    public static LoginUIManager Instance;

    [SerializeField]
    private TMP_Text LoginStateText;
    [SerializeField]
    private TMP_InputField userNameInput, passwordInput;
    [SerializeField]
    private Button loginButton, registerButton;

    private void Awake()
    {
        Instance = this;
        loginButton.onClick.AddListener(Login);
        registerButton.onClick.AddListener(Register);
    }

    private async void Start()
    {
        try
        {
            UserInfo info = SaveSystemManager.Instance.LoadUserInfo();
            UserInfo user = await DataAccess.Instance.GetUser(info.Username, info.Password);
            SceneManager.LoadScene(1);
            LoginStateText.text = "Login Success!";
        } catch
        {
            Debug.Log("No data to load.");
        }
        
    }

    public async void Login()
    {
        string name = userNameInput.text;
        string password = passwordInput.text;
        try
        {
            UserInfo user = await DataAccess.Instance.GetUser(name, password);
            LoginStateText.text = "Login Success!";

            SaveSystemManager.Instance.SaveUserInfo(name, password);

            SceneManager.LoadScene(1);

        } catch (Exception e) {
            LoginStateText.text = "Wrong Username/Password or account doesn't exist.";
            LoginStateText.text = e.ToString();
        }       
    }    

    private async void Register()
    {
        string name = userNameInput.text;
        string password = passwordInput.text;
        try 
        {
            UserInfo user = await DataAccess.Instance.GetUser(name, password);
            LoginStateText.text = "Account already existed!";

        } catch {
            try
            {
                await DataAccess.Instance.CreateUser(new UserInfo(name, password));
                SaveSystemManager.Instance.SaveUserInfo(name, password);
                LoginStateText.text = "Create Account!";
                SceneManager.LoadScene(1);
            }
            catch (Exception e)
            {
                LoginStateText.text = e.ToString();
            }
        }            
    }    
}
