using IStore.Entity;
using IStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IStore.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly CategoriesService _categoryService;
        public CategoryController(CategoriesService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index() 
        {
            ViewBag.categories = _categoryService.GetCategory();
            return View("ListCategory");
        }
        public IActionResult Create() { return View("CreateCategory"); }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.SaveCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            ViewBag.data = _categoryService.FindCategory(id);
            return View("EditCategory", ViewBag.data);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
        
    }
}
