using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Authentication;
using static UnityEditor.Progress;

public class DataAccess : MonoBehaviour
{
    private string connectionString = "mongodb://kamkam:zhiyvu0808@ac-ltfgj36-shard-00-00.ajunidn.mongodb.net:27017,ac-ltfgj36-shard-00-01.ajunidn.mongodb.net:27017,ac-ltfgj36-shard-00-02.ajunidn.mongodb.net:27017/?ssl=true&replicaSet=atlas-1dpjia-shard-0&authSource=admin&retryWrites=true&w=majority&appName=CandyCrs";
    private string databaseName = "CandyDatabase";

    private string userCollection = "userCollection";
    private string itemCollection = "itemsCollection";
    private string ingredientCollection = "ingredientsCollection";
    private string outfitCollection = "outfitCollection";

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
    public async Task<UserInfo> GetUser(string name, string password)
    {
        var filter = Builders<UserInfo>.Filter.Eq(n => n.Username, name) &
            Builders<UserInfo>.Filter.Eq(n => n.Password, password);

        var results = await ConnectToMongo<UserInfo>(userCollection).FindAsync(filter);
        return await results.FirstAsync();
    }
    public async Task<List<UserInfo>> GetAllUsers()
    {
        IMongoCollection<UserInfo> userInfos = ConnectToMongo<UserInfo>(userCollection);
        var results = await userInfos.FindAsync(c => true);
        return results.ToList();
    }

    public Task AddItem(ItemGM item)
    {
        IMongoCollection<ItemGM> itemInfos = ConnectToMongo<ItemGM>(itemCollection);
        return itemInfos.InsertOneAsync(item);
    }
    public async Task<List<ItemGM>> GetAllItems(string name)
    {
        var filter = Builders<ItemGM>.Filter.Eq(n => n.userName, name);

        IMongoCollection<ItemGM> itemInfos = ConnectToMongo<ItemGM>(itemCollection);
        var results = await itemInfos.FindAsync(filter);
        return results.ToList();
    }

    public Task AddIngredients(IngredientInfo ingredient)
    {
        IMongoCollection<IngredientInfo> ingredientInfos = ConnectToMongo<IngredientInfo>(ingredientCollection);
        return ingredientInfos.InsertOneAsync(ingredient);
    }
    public async Task<List<IngredientInfo>> GetAllIngredients(string name)
    {
        var filter = Builders<IngredientInfo>.Filter.Eq(n => n.userName, name);

        IMongoCollection<IngredientInfo> itemInfos = ConnectToMongo<IngredientInfo>(ingredientCollection);
        var results = await itemInfos.FindAsync(filter);
        return results.ToList();
    }   
    public async void DeleteIngredient(string itemID, string name)
    {
        var filter = Builders<IngredientInfo>.Filter.Eq(n => n.itemID, itemID) &
            Builders<IngredientInfo>.Filter.Eq(n => n.userName, name);
        var results = await ConnectToMongo<IngredientInfo>(ingredientCollection).DeleteOneAsync(filter);
    }

    public Task AddOutfit(ItemGM outfit)
    {
        IMongoCollection<ItemGM> itemInfos = ConnectToMongo<ItemGM>(outfitCollection);
        return itemInfos.InsertOneAsync(outfit);
    }
    public async Task<List<ItemGM>> GetAllOutfits(string name)
    {
        var filter = Builders<ItemGM>.Filter.Eq(n => n.userName, name);

        IMongoCollection<ItemGM> itemInfos = ConnectToMongo<ItemGM>(outfitCollection);
        var results = await itemInfos.FindAsync(filter);
        return results.ToList();
    }

    public async Task<int> UpdateCoins(string name, string password, int coins)
    {
        var filter = Builders<UserInfo>.Filter.Eq(n => n.Username, name) &
            Builders<UserInfo>.Filter.Eq(n => n.Password, password);
        var results = await ConnectToMongo<UserInfo>(userCollection).FindAsync(filter);
        var user = await results.FirstAsync();

        int newCoins = coins + user.Coins;
        if(newCoins < 0)
        {
            return user.Coins; 
        }    
        else
        {
            var update = Builders<UserInfo>.Update.Set(c => c.Coins, newCoins);

            var updateCoins = ConnectToMongo<UserInfo>(userCollection);
            updateCoins.UpdateOne(filter, update);

            return newCoins;
        }
    }
}

