using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPT_JUEGOS.Models;
using TPT_JUEGOS.Context;
using Microsoft.EntityFrameworkCore;

namespace TPT_JUEGOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuariosDatabaseContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UsuariosDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InicioSesion()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InicioSesion(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var inputUsuario = viewModel.UsuarioOEmail;

                var usuarioEncontrado = await _context.Usuarios
                    .FirstOrDefaultAsync(u =>
                        (u.CORREO_USUARIO == inputUsuario || u.NOMBRE_USUARIO == inputUsuario) &&
                         u.CONTRASENA_USUARIO == viewModel.Contrasena);

                if (usuarioEncontrado == null)
                {
                    ModelState.AddModelError(string.Empty, "Usuario, correo o contraseña incorrectos.");
                    return View(viewModel);
                }

                

                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}