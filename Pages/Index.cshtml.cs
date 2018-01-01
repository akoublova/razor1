using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razor1.Model;
using razor1.Repository;

namespace razor1.Pages {
    public class IndexModel : PageModel {

        public IList<Recipe> Recipes;

        public void OnGet () {
            var repo = new RecipeRepository ();
            Recipes = repo.GetAllRecipes ();
        }
    }
}