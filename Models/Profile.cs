using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenerateUserApi.Models
{
    public class Profile
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string type_account { get; set; }
        public int experience { get; set; }
        public int age { get; set; }
        public string skill { get; set; }
    }
}
