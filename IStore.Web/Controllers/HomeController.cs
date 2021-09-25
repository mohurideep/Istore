using IStore.Services;
using IStore.Web.Models;
using IStore.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoriesService _categoryService;
        public HomeController(ILogger<HomeController> logger, CategoriesService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Categories = _categoryService.GetCategory();
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
