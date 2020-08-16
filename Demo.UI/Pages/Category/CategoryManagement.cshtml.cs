using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Application.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.UI.Pages.Category
{
    public class CategoryManagementModel : PageModel
    {
        public ICategoryRepository _categoryRepository;

        [BindProperty]
        public List<Core.DbModels.Category> categoryList { get; set; }

        [TempData]
        public string Message { get; set; }
        public CategoryManagementModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            categoryList = (List<Core.DbModels.Category>)await _categoryRepository.GetAll();

            return Page();
        }
        public async Task<IActionResult> OnGetDelete(int id)
        {
            if (id > 0)
            {
                var count = await _categoryRepository.Delete(id);
                Message = "Category Deleted Successfully !";
            }
            return RedirectToPage("/Category/CategoryManagement");



        }
    }

}