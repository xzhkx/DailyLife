using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using UnityEngine;

public class AchievementInfo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string userName;
    public string title;
    public bool hasEarned;

    public AchievementInfo(string userName, string title)
    {
        this.userName = userName;
        this.title = title;
        hasEarned = false;
    }
}
