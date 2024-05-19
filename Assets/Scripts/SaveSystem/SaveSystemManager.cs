using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemManager : MonoBehaviour
{
    public static SaveSystemManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SaveUserInfo(string name, string password)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.Login";
        FileStream stream = new FileStream(path, FileMode.Create);

        UserInfo data = new UserInfo(name, password);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public UserInfo LoadUserInfo()
    {
        string path = Application.persistentDataPath + "/Player.Login";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UserInfo data = formatter.Deserialize(stream) as UserInfo;
            stream.Close();

            return data;

        } else
        {
            Debug.Log("Cant find save file in" + path);
            return null;
        } 
    }
}
