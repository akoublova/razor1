using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razor1.Repository;

namespace razor1.Pages
{
    public class RecipeDetailModel : PageModel
    {
        public Recipe Recipe { get; set; }

        public void OnGet(string id)
        {
            if (id == null)
                return;
            var repo = new RecipeRepository();
            Recipe = repo.GetRecipe(id);
        }
    }
}
