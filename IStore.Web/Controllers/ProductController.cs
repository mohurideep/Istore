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
            ProductTable();
            return View();
        }
        [HttpGet]
        public IActionResult ProductTable()
        {
            var productList = _productsService.GetProduct();
            return PartialView(productList);
        }
        public IActionResult ListProduct(string search)
        {
            var data = _productsService.GetProduct();
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(x =>x.Name!=null && x.Name.ToLower().Contains(search)).ToList();
            }
            return PartialView("ProductTable",data);
        }
        public IActionResult CreateProduct()
        {
            var Categories = _categoriesService.GetCategory();
            return PartialView("CreateProduct",Categories);
        }
        [HttpPost]
        public IActionResult CreateProduct(CategoryViewModel model)
        {
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.Category = _categoriesService.FindCategory(model.CategoryID);
            _productsService.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }
        
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var data = _productsService.FindProduct(id);
            return PartialView(data);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productsService.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            _productsService.DeleteProduct(id);
            //var productList = _productsService.GetProduct();
            //return PartialView("ProductTable", productList);
            return RedirectToAction("ProductTable");
        }
    }
}
