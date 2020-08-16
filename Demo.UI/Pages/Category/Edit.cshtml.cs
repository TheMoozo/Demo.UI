using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Application.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.UI.Pages.Category
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Core.DbModels.Category category { get; set; }
        [TempData]
        public string Message { get; set; }

        ICategoryRepository _categoryRepository;
        public EditModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            category = await _categoryRepository.Get(id);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var count = await _categoryRepository.Update(category);
                if (count > 0)
                {
                    Message = "Category Updated Successfully !";
                }
            }

            return RedirectToPage("/Category/CategoryManagement");
            
        }
    }
}