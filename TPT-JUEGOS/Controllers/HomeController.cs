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
            ViewData["OcultarNavbar"] = true;
            return View();
        }
        public async Task<IActionResult> Index(string busqueda)
        {
            ViewBag.Usuario = HttpContext.Session.GetString("usuario");
            ViewBag.TipoUsuario = HttpContext.Session.GetInt32("tipo");

            var juegos = _context.Juegos.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                juegos = juegos.Where(j => j.NOMBRE_JUEGO.Contains(busqueda));
            }

            return View(juegos.ToList());
        }


        public IActionResult InicioSesion()
        {
            ViewData["OcultarNavbar"] = true;
            return View();
        }

        public HttpContext GetHttpContext()
        {
            return HttpContext;
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("IndexBienvenida");
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

                HttpContext.Session.SetString("UsuarioId", usuarioEncontrado.Id.ToString());
                HttpContext.Session.SetString("NombreUsuario", usuarioEncontrado.NOMBRE_USUARIO);

                estado = "exito";
            }

            if (estado == "exito")
            {
                HttpContext.Session.SetString("usuario", usuarioEncontrado.NOMBRE_USUARIO);
                HttpContext.Session.SetInt32("tipo", usuarioEncontrado.TIPO_USUARIO);

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
