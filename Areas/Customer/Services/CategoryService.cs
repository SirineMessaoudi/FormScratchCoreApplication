using FormScratchCoreApplication.Data;
using FormScratchCoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormScratchCoreApplication.Areas.Customer.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> Create(Category category)
        {
            _db.categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<Category> EditCategory(int id, Category category)
        {
            //recuperer une par son id : 
            var CatInDb = _db.categories.SingleOrDefault(c => c.Id == id);
            //faire l'update sur Json : 
            _db.Update(category);
            //var CatInDb = await _db.categories.FindAsync(id);
            //CatInDb.Name = category.Name;

            //enregister les changement : 
            await _db.SaveChangesAsync();
            //retourner la category update 
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            // retourner une liste des categories : 
            return await _db.categories.ToListAsync();
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var CatInDb = await _db.categories.FindAsync(id);
            _db.Remove(CatInDb);
            await _db.SaveChangesAsync();
            return CatInDb;

        }
    }
}
