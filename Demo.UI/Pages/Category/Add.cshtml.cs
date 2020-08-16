using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Application.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.UI.Pages.Category
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Core.DbModels.Category category { get; set; }
        [TempData]
        public string Message { get; set; }

        ICategoryRepository _categoryRepository;
        public AddModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var count = await _categoryRepository.Add(category);
                if (count > 0)
                {
                    Message = "New Category Added Successfully !";
                }
            }

            return RedirectToPage("/Category/CategoryManagement");
        }
    }
}