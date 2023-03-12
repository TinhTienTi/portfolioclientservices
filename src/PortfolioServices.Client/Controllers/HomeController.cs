using Microsoft.AspNetCore.Mvc;
using PortfolioServices.Bo.Interfaces;
using ProfolioClient.App.Models;
using System.Diagnostics;

namespace ProfolioClient.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider serviceProvider;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            this.serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            var pb = serviceProvider.GetService<IProfileBo>();

            var data = await pb.GetHomeInfoQueryableAsync("vi");

            ViewData["HomeData"] = data;

            return View();
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