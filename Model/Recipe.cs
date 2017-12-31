using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

    public class Recipe {
        [BsonId]
        public ObjectId ObjectId {get; set;}

        [BsonIgnore]
        public string Id {get {return ObjectId.ToString();}}

        [BsonElement("abc")]
        public double Abcd {get; set;}

        /* [BsonId]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public DateTime Created { get; set; }
        public List<string> Tags { get; set; } */
    }