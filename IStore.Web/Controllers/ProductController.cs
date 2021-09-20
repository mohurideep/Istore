using IStore.Database;
using IStore.Entity;
using IStore.Services;
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

        public ProductController(ProductsService productsService)
        {
            _productsService = productsService;
        }
        public IActionResult Index()
        {
            ProductTable();
            return View();
        }
        [HttpGet]
        public IActionResult ProductTable()
        {
            ViewBag.ProductsList = _productsService.GetProduct();
            return PartialView(ViewBag.ProductsList);
        }
        public IActionResult ListProduct(string search)
        {
            var data = _productsService.GetProduct();
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(x =>x.Name!=null && x.Name.ToLower().Contains(search)).ToList();
                ViewBag.ProductsList = data;
            }
            return PartialView("ProductTable");
        }
        public IActionResult Create()
        {
            return PartialView("CreateProduct");
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productsService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }
        
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            ViewBag.data = _productsService.FindProduct(id);
            return PartialView(ViewBag.data);
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
            return RedirectToAction("Index");
        }
    }
}
