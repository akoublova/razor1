using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using razor1.Model;

namespace razor1.Repository {
    public interface IRecipeRepository {
        IList<Recipe> GetAllRecipes ();

        Recipe GetRecipe (string id);

        Recipe AddRecipe (Recipe recipe);

        bool RemoveRecipe (string id);

        void RemoveAllRecipes ();

        IList<string> GetTags();
        
        IList<string> GetIngredients();
    }
}