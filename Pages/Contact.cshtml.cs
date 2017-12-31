using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razor1.Model;

namespace razor1.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            var repo = new RecipeRepository();
            var coll = repo.GetAllRecipes();

            Message = string.Join("\n", coll.Select(recipe => recipe.Id));
        }
    }
}
