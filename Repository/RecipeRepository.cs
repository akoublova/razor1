using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using razor1.Model;

namespace razor1.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private MongoDBContext dbContext;

        public RecipeRepository()
        {
            dbContext = new MongoDBContext();
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            recipe.Created = DateTime.Now;
            dbContext.Recipes.InsertOne(recipe);
            return recipe;
        }

        public IList<Recipe> GetAllRecipes()
        {
            return dbContext.Recipes.Find(m => true).ToList();
        }

        public Recipe GetRecipe(string id)
        {
            return dbContext.Recipes.Find(recipe => recipe.ObjectId == ObjectId.Parse(id)).FirstOrDefault();
        }

        public void RemoveAllRecipes()
        {
            dbContext.Recipes.DeleteMany(recipe => true);
        }

        public bool RemoveRecipe(string id)
        {
            return dbContext.Recipes.DeleteOne(recipe => recipe.Id == id).DeletedCount == 1;
        }

        public IList<string> GetIngredients()
        {
            return dbContext.Recipes.Distinct<string>("Ingredients", new BsonDocument()).ToList();
        }

        public IList<string> GetTags()
        {
            return dbContext.Recipes.Distinct<string>("Tags", new BsonDocument()).ToList();
        }
    }
}