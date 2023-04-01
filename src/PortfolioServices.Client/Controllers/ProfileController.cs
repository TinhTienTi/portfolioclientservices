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

                var data = pb.GetHomeInfoQueryableAsync("vi");
                var services = pb.GetServicesInfoQueryableAsync("vi");
                var about = pb.GetAboutInfoQueryableAsync("vi");
                var client = pb.GetClientInfoQueryableAsync("vi");

                ViewData["HomeData"] = await data;
                ViewData["ServiceData"] = await services;
                ViewData["AboutData"] = await about;
                ViewData["ClientData"] = await client;

                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetServiceInfo()
        {
            try
            {
                var pb = serviceProvider.GetService<IProfileBo>();

                var data = await pb.GetServicesInfoQueryableAsync("vi");

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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}