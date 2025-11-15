using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPT_JUEGOS.Context; 
using TPT_JUEGOS.Models;

namespace TPT_JUEGOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UsuariosDatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, UsuariosDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult IndexBienvenida()
            {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult InicioSesion()
        {
            return View();
        }

        
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> InicioSesion(Usuario usuarioIngresado)
        {
            IActionResult resultado = View();
            string estado = "validar";        

            var inputLogin = usuarioIngresado.NOMBRE_USUARIO;
            var inputPass = usuarioIngresado.CONTRASENA_USUARIO;
            Usuario usuarioEncontrado = null;

            while (estado == "validar")
            {
                if (string.IsNullOrEmpty(inputLogin) || string.IsNullOrEmpty(inputPass))
                {
                    ViewData["MensajeError"] = "Por favor completa todos los campos.";
                    estado = "error";
                    continue;
                }

                usuarioEncontrado = await _context.Usuarios
                    .FirstOrDefaultAsync(u =>
                        (u.CORREO_USUARIO == inputLogin || u.NOMBRE_USUARIO == inputLogin) &&
                         u.CONTRASENA_USUARIO == inputPass);

                if (usuarioEncontrado == null)
                {
                    ViewData["MensajeError"] = "Usuario o contraseña incorrectos.";
                    estado = "error";
                    continue;
                }

                estado = "exito";
            }

            if (estado == "exito")
            {
                resultado = RedirectToAction("Index");
            }

            return resultado;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
