using FormScratchCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormScratchCoreApplication.Areas.Customer.Services
{
    public interface ICategoryServices
    {
        //les fonctions qu'on va etre les definer dans le service CategoryService:
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> EditCategory(int id, Category category);
        Task<Category> Create(Category category);
        Task<Category> DeleteCategory(int id);
    }
}
