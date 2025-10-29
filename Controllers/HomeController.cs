using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductosExternosMVC.Models;
using ProductosExternosMVC.Services;

namespace ProductosExternosMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ServicioProductos servicioProductos = new ServicioProductos();

            ViewBag.Productos = await servicioProductos.Todos();

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
