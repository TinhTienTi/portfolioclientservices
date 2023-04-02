using Microsoft.AspNetCore.Mvc;
using PortfolioServices.Bo.Interfaces;
using ProfolioClient.App.Models;
using System.Diagnostics;

namespace ProfolioClient.App.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IServiceProvider serviceProvider;

        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            this.serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var pb = serviceProvider.GetService<IProfileBo>();

                var data = pb.GetHomeInfoAsync("vi");
                var services = pb.GetServicesInfoAsync("vi");
                var about = pb.GetAboutInfoAsync("vi");
                var client = pb.GetClientInfoAsync("vi");
                var portfolio = pb.GetPortfolioInfoAsync("vi");

                ViewData["HomeData"] = await data;
                ViewData["ServiceData"] = await services;
                ViewData["AboutData"] = await about;
                ViewData["ClientData"] = await client;
                ViewData["PortfolioData"] = await portfolio;

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { code = 500, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetServiceInfo()
        {
            try
            {
                var pb = serviceProvider.GetService<IProfileBo>();

                var data = await pb.GetServicesInfoAsync("vi");

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int code, string message)
        {       
            return View();
        }
    }
}