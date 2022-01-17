using FormScratchCoreApplication.Data;
using FormScratchCoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormScratchCoreApplication.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        //action qui lister tous le contenu :
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        //HTTP-GET 
        //Async |await permettent d'appeler +ieurs fonctionnalités d'une maniere asynchrone: 
        public async Task<IActionResult> Index()
        {
            return View(await _db.categories.ToListAsync());
        }
        //HTTP-GET 
        public IActionResult Create()
        {
            return View();
        }
        // pour Create : 
        //HTTP-POST
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            //Si le modèle introduit est valide
            {
                //ajouter category : 
                _db.categories.Add(category);
                //enregistrer les modification : 
                await _db.SaveChangesAsync();

                //return RedirectToAction("Index", "Category");
                //si vous avez le controle sur le meme controller : redirection  
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        //pour edit get pour récuperer à partir de l'id  :
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            //sinon 
            var cat = await _db.categories.FindAsync(id);
            return View(cat);
        }
        //pour edit post pour sauvegarder 'save' l'update:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                //Update peut être remplacé par mapping automatique ou manuelle

                _db.Update(category);
               // enregistrer les modification:
                await _db.SaveChangesAsync();
               // redirection
                return RedirectToAction(nameof(Index));
            }
            
            return View(category);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Category category)
        //{
        //    //Mapping manuelle
        //    _db.Update(category);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));

        //}
        //pour delete get pour récuperer à partir de l'id: 
        //HTTP-GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            //rechercher par id : 
            var cat = await _db.categories.FindAsync(id);
            return View(cat);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            //rechercher par id : 
            var cat = await _db.categories.FindAsync(id);
            //si null donc rien faire:
            if (cat == null) return View();
            //sinon supprimer
            _db.categories.Remove(cat);
            //enregistrer les modification :
            await _db.SaveChangesAsync();
            //  redirection
            return RedirectToAction(nameof(Index));
        }
    }
}
