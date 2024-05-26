using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGM 
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string userName;
    public string itemID;

    public ItemGM(string userName, string itemID)
    {
        this.userName = userName;
        this.itemID = itemID;
    }
}
