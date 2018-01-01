using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razor1.Model;
using razor1.Repository;

namespace razor1.Pages {
    public class NewRecipeModel : PageModel {
        public NewRecipeModel () {
            Repository = new RecipeRepository ();
        }

        private IRecipeRepository Repository { get; set; }

        public IList<string> Tags { get; set; }

        public IList<string> Ingredients { get; set; }

        public Recipe Recipe { get; set; }

        public void OnGet () {
            Tags = Repository.GetTags ();
            Ingredients = Repository.GetIngredients ();
            // Recipe = new Recipe () {
            //     Ingredients = new List<Ingredient> () {
            //     new Ingredient () {
            //     Name = "",
            //     Quantity = ""
            //     }
            //     }
            // };
        }

        public IActionResult OnPost () {
            if (!ModelState.IsValid) {
                return Page ();
            }

            var addedRecipe = Repository.AddRecipe (Recipe);
            return RedirectToPage ($"/RecipeDetail?id={addedRecipe.Id}");
        }
    }
}