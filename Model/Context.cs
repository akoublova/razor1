using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Settings;

public class NoteContext
{
    private readonly IMongoDatabase _database = null;

    public NoteContext(IOptions<Settings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        if (client != null)
            _database = client.GetDatabase(settings.Value.Database);
    }

    public IMongoCollection<Recipe> Recipes
    {
        get
        {
            return _database.GetCollection<Recipe>("Recipe");
        }
    }
}