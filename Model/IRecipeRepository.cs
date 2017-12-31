using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

public interface IRecipeRepository
{
    IList<Recipe> GetAllRecipes();

    Recipe GetRecipe(string id);

    Recipe AddRecipe(Recipe recipe);

    bool RemoveRecipe(string id);

    void RemoveAllRecipes(); 

    // TODO update
}