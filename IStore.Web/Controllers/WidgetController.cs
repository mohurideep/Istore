using IStore.Services;
using IStore.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStore.Web.Controllers
{
    public class WidgetController : Controller
    {

        private readonly ProductsService _productService;
        public WidgetController(ProductsService productsService)
        {
            _productService = productsService;
        }
        public IActionResult ProductsWidget(bool isLatestProducts , int? CategoryId=0)
        {
            ProductsWidgetViewModel model = new ProductsWidgetViewModel();
            model.IsLatestProduct = isLatestProducts;

            if(isLatestProducts)
            {
                model.Products = _productService.GetLatestProduct(4);
            }
            else if(CategoryId.HasValue && CategoryId.Value>0)
            {
                model.CategoryId = CategoryId.Value;
                model.Products = _productService.GetProductByCategory(CategoryId.Value, 4);
            }
            else
            {
                model.Products = _productService.GetProduct(1,8);
            }
            return PartialView(model);
        }
    }
}
