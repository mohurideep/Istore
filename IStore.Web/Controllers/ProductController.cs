using IStore.Database;
using IStore.Entity;
using IStore.Services;
using IStore.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsService _productsService;
        private readonly CategoriesService _categoriesService;

        public ProductController(ProductsService productsService, CategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ProductTable(int? pageNo)
        {
            ProductViewModel model = new ProductViewModel();
            model.Product = _productsService.GetProduct();
            return PartialView(model);
        }
        public IActionResult ListProduct(string search)
        {
            ProductViewModel model = new ProductViewModel();
            model.Product = _productsService.GetProduct();
            if (!string.IsNullOrEmpty(search))
            {
                model.Product = model.Product.Where(x =>x.Name!=null && x.Name.ToLower().Contains(search)).ToList();
            }
            return PartialView("ProductTable", model);
        }

        public IActionResult CreateProduct()
        {
            NewProductViewModel model = new NewProductViewModel();
            model.AvailableCategories = _categoriesService.GetCategory();
            return PartialView("CreateProduct", model);
        }

        [HttpPost]
        public IActionResult CreateProduct(NewProductViewModel model)
        {
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.ImageURL = model.ImageURL;
            newProduct.Category = _categoriesService.FindCategory(model.CategoryID);
            newProduct.EntryDate = DateTime.Now;
            _productsService.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }
        
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            EditProductViewModel model = new EditProductViewModel();
            var product = _productsService.FindProduct(id);

            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.CategoryID = product.Category != null ? product.Category.ID : 0;
            model.ImageURL = product.ImageURL;

            model.AvailableCategories = _categoriesService.GetCategory(); ;
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult UpdateProduct(EditProductViewModel model)
        {
            var existingProduct = _productsService.FindProduct(model.ID);
            existingProduct.Name = model.Name;
            existingProduct.Description = model.Description;
            existingProduct.Price = model.Price;

            //existingProduct.Category = null; //mark it null. Because the referncy key is changed below
            //existingProduct.Category.ID = model.CategoryID;

            //dont update imageURL if its empty
            if (!string.IsNullOrEmpty(model.ImageURL))
            {
                existingProduct.ImageURL = model.ImageURL;
            }
            _productsService.UpdateProduct(existingProduct);
            return RedirectToAction("ProductTable");
        }

        public IActionResult DeleteProduct(int id)
        {
            _productsService.DeleteProduct(id);
            return RedirectToAction("ProductTable");
        }
    }
}
