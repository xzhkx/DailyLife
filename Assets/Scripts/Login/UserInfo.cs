using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class UserInfo 
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Coins { get; set; }

    public UserInfo(string name, string password)
    {
        Username = name;
        Password = password;
        Coins = 0;
    }
}
