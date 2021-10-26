using IStore.Services;
using IStore.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly ProductsService _productsService;
        private readonly CategoriesService _categoriesService;

        public ShopController(ProductsService productsService, CategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }
        
        public IActionResult Index(string searchTerm, int? minPrice, int? maxPrice, int? categoryId)
        {
            ShopViewModel model = new ShopViewModel();
            model.FeaturedCategories = _categoriesService.GetFeaturedCategory();
            model.MaxPrice = _productsService.GetMaxPrice();
            model.Products = _productsService.SearchProducts(searchTerm, minPrice, maxPrice, categoryId);
            
            return View(model);
        }
        public IActionResult CheckOut()
        {
            CheckOutViewModel model = new CheckOutViewModel();
            var CartProductsCookie = Request.Cookies["CartProducts"];

            if(CartProductsCookie != null)
            {
                model.CartProductIds = CartProductsCookie.Split('-').Select(x => int.Parse(x)).ToList();

                model.CartProducts = _productsService.GetProduct(model.CartProductIds);
            }
            return View(model);
        }
    }
}
