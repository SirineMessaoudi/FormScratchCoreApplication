using FormScratchCoreApplication.Areas.Customer.Services;
using FormScratchCoreApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormScratchCoreApplication.Areas.Customer.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryServices categoryService;
        public CategoryController(ICategoryServices categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetAllCategories();
            return Ok(categories);
        }
        //pour créeer une categorie
        [HttpPost]
        public async Task<IActionResult> CreateCategorie(Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            //sinon 
            var categories = await categoryService.Create(category);
            return Ok(categories);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCategorie(int id, Category category)
        {
            var categories = await categoryService.EditCategory(id, category);
            return Ok(categories);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie(int id)
        {

            var categorie = await categoryService.DeleteCategory(id);
            return Ok(categorie);
        }









    }
}
