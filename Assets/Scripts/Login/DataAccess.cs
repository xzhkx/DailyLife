using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MongoDB.Driver;
using System.Threading.Tasks;

public class DataAccess : MonoBehaviour
{
    private string connectionString = "mongodb://kamkam:zhiyvu0808@ac-ltfgj36-shard-00-00.ajunidn.mongodb.net:27017,ac-ltfgj36-shard-00-01.ajunidn.mongodb.net:27017,ac-ltfgj36-shard-00-02.ajunidn.mongodb.net:27017/?ssl=true&replicaSet=atlas-1dpjia-shard-0&authSource=admin&retryWrites=true&w=majority&appName=CandyCrs";
    private string databaseName = "CandyDatabase";
    private string userCollection = "userCollection";

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

    public async Task<UserInfo> GetUser(string name, string password)
    {
        var filter = Builders<UserInfo>.Filter.Eq(n => n.Username, name) &
            Builders<UserInfo>.Filter.Eq(n => n.Password, password);

        var results = await ConnectToMongo<UserInfo>(userCollection).FindAsync(filter);
        return await results.FirstAsync();
    }    
}

