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

        public ShopController(ProductsService productsService)
        {
            _productsService = productsService;
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
