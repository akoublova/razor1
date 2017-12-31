using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

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

        Recipe IRecipeRepository.AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        IList<Recipe> IRecipeRepository.GetAllRecipes()
        {
            throw new NotImplementedException();
        }

        IList<string> IRecipeRepository.GetIngredients()
        {
            return dbContext.Recipes.Distinct<string>("Ingredients", new BsonDocument()).ToList();
        }

        Recipe IRecipeRepository.GetRecipe(string id)
        {
            throw new NotImplementedException();
        }

        IList<string> IRecipeRepository.GetTags()
        {
            return dbContext.Recipes.Distinct<string>("Tags", new BsonDocument()).ToList();
        }

        void IRecipeRepository.RemoveAllRecipes()
        {
            throw new NotImplementedException();
        }

        bool IRecipeRepository.RemoveRecipe(string id)
        {
            throw new NotImplementedException();
        }
    }
}