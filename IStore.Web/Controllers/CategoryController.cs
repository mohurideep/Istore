using IStore.Database;
using IStore.Entity;
using IStore.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore.Web.Controllers
{
    public class CategoryController : Controller
    {

        private IStoreContext _storeContext;
        public CategoryController(IStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IActionResult Index() 
        {
            var categories = _storeContext.Categories.ToList();
            return View("ListCategory", categories);
        }
        public IActionResult Create() { return View("CreateCategory"); }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _storeContext.Categories.Add(category);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int id)
        {
            var data = _storeContext.Categories.Find(id);
            
            return View("EditCategory", data);
        }

        public IActionResult UpdateCategory(Category category)
        {
            _storeContext.Categories.Update(category);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var data = _storeContext.Categories.Find(id);
            _storeContext.Categories.Remove(data);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
