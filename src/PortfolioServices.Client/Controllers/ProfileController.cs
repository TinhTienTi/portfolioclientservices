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

                var data = await pb.GetHomeInfoQueryableAsync("vi");

                ViewData["HomeData"] = data;

                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetAboutInfo()
        {
            try
            {
                var pb = serviceProvider.GetService<IProfileBo>();

                var data = await pb.GetAboutInfoQueryableAsync("vi");

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
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