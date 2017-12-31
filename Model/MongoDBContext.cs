using MongoDB.Driver;
using System;

public class MongoDBContext 
    { 
        public static string ConnectionString { get; set; } 
        public static string DatabaseName { get; set; } 
        public static bool IsSSL { get; set; } 
 
        private IMongoDatabase _database { get; } 
 
        public MongoDBContext() 
        { 
            ConnectionString = "mongodb://127.0.0.1:27017";
            DatabaseName = "anezka11";

            try 
            { 
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString)); 
                if (IsSSL) 
                { 
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 }; 
                } 
                var mongoClient = new MongoClient(settings); 
                _database = mongoClient.GetDatabase(DatabaseName); 
            } 
            catch (Exception ex) 
            { 
                throw new Exception("Can not access to db server.", ex); 
            } 
        } 
 
        public IMongoCollection<Recipe> Recipes 
        { 
            get 
            { 
                return _database.GetCollection<Recipe>("kolekce11"); 
            } 
        } 
    } 