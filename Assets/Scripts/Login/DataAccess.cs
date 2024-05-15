using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MongoDB.Driver;
using System.Threading.Tasks;

public class DataAccess : MonoBehaviour
{
    private const string connectionString = "mongodb+srv://kamkam:zhiyvu0808@candycrs.ajunidn.mongodb.net/?retryWrites=true&w=majority&appName=CandyCrs";
    private const string databaseName = "CandyDatabase";
    private const string userCollection = "userCollection";

    public static DataAccess Instance;

    private void Awake()
    {
        Instance = this;
    }

    public IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        MongoClient client = new MongoClient(connectionString);
        return client.GetDatabase(databaseName).GetCollection<T>(collection);
    }

    public Task CreateUser(UserInfo user)
    {
        IMongoCollection<UserInfo> userInfos = ConnectToMongo<UserInfo>(userCollection);
        return userInfos.InsertOneAsync(user);
    }

    public async Task<List<UserInfo>> GetAllUsers()
    {
        IMongoCollection<UserInfo> userInfos = ConnectToMongo<UserInfo>(userCollection);
        var results = await userInfos.FindAsync(c => true);
        return results.ToList();
    }
}
