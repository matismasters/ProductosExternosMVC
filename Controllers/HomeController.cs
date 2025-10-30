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
        [HttpPost]
        public async Task<IActionResult> CrearProducto(CrearProductoDto _crearProductoDto)
        {
            // Validaciones varias
            // ....

            ServicioProductos servicioProductos = new ServicioProductos();
            ProductoDto? producto = await servicioProductos.Crear(_crearProductoDto.nombre, _crearProductoDto.precio);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> BorrarProducto(BorrarProductoDto _borrarProductoDto)
        {
            // Validaciones varias
            // ....

            ServicioProductos servicioProductos = new ServicioProductos();
            await servicioProductos.Borrar(_borrarProductoDto.id);

            return RedirectToAction("Index");
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
