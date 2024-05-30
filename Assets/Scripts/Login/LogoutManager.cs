using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LogoutManager : MonoBehaviour
{
    public void Logout()
    {
        string path = Application.persistentDataPath + "/Player.Login";
        if(File.Exists(path))
        {
            File.Delete(path);
        }

        SceneManager.LoadScene(0);
    }
}
