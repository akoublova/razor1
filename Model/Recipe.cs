using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace razor1.Model {
    public class Recipe {
        
        [BsonId]
        public ObjectId ObjectId { get; set; }

        [BsonIgnore]
        public string Id { get { return ObjectId.ToString (); } }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public TimeSpan PrepTime { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public string Method { get; set; }

        public DateTime Created { get; set; }

        public List<string> Tags { get; set; }
    }
}