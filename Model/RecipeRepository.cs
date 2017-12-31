using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace razor1.Model
{
    public class RecipeRepository : IRecipeRepository
    {
        private MongoDBContext dbContext;

        public RecipeRepository()
        {
            dbContext = new MongoDBContext();
        }

        public void AddRecipe(Recipe item)
        {
            dbContext.Recipes.InsertOne(item);
        }

        public IList<Recipe> GetAllRecipes()
        {
            return dbContext.Recipes.Find(m => true).ToList();
        }

        public Recipe GetRecipe(string id)
        {
            return dbContext.Recipes.Find(recipe => recipe.Id == id).FirstOrDefault();
        }

        public void RemoveAllRecipes()
        {
            dbContext.Recipes.DeleteMany(recipe => true);
        }

        public bool RemoveRecipe(string id)
        {
            return dbContext.Recipes.DeleteOne(recipe => recipe.Id == id).DeletedCount == 1;
        }

        public Task<bool> UpdateRecipe(Recipe newRecipe)
        {
            return dbContext.Recipes.UpdateOne(recipe => recipe.Id == newRecipe.Id, newRecipe);
        }
    }
}