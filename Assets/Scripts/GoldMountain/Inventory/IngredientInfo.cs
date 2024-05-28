using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using UnityEngine;

public class IngredientInfo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string userName;
    public string itemID;

    public IngredientInfo(string userName, string itemID)
    {
        this.userName = userName;
        this.itemID = itemID;
    }
}
