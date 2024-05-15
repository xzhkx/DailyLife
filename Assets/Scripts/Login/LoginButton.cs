using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LoginButton : MonoBehaviour
{
    public async void Login()
    {
        UserInfo user = new UserInfo("Hoang Khanh", "123");
        
        await DataAccess.Instance.CreateUser(user);
        
        var infos = await DataAccess.Instance.GetAllUsers();
        foreach(UserInfo info in infos)
        {
            Debug.Log("Player name : " + info.Username);
        }
    }

}
