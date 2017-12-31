using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

public interface IRecipeRepository
{
    IList<Recipe> GetAllRecipes();
    Task<Recipe> GetRecipe(string id);
    Task AddRecipe(Recipe item);
    Task<bool> RemoveRecipe(string id);
    Task<bool> UpdateRecipe(string id, string body);
    Task<bool> UpdateAllRecipes(string id, string body);
    Task<bool> RemoveAllRecipe();
}