using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Inventario.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Inventario_DB _contextDB;

        public HomeController(ILogger<HomeController> logger, Inventario_DB contextDB)
        {
            _logger = logger;
            _contextDB = contextDB;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Initialize();
            var miCookie = HttpContext.Request.Cookies["Cookie_Inventario"];
            if (miCookie != null) 
            {
                List<Usuario> listaUsuarios = _contextDB.Usuario.ToList();
                foreach(var user in listaUsuarios)
                {
                    if (user.Correo == miCookie)
                    {
                        if (user.TipoUsuario == "Admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Correo, string Contrasena)
        {
            List<Usuario> listaUsuarios = _contextDB.Usuario.ToList();
            foreach (var user in listaUsuarios)
            {
                if (user.Correo == Correo && user.Contrasena == Contrasena)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(365);
                    options.IsEssential = true;
                    options.Path = "/";
                    HttpContext.Response.Cookies.Append("Cookie_Inventario", Correo, options);

                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Correo y/o contrasena incorrectos";
            return View();
        }

        public string Cookies()
        {
            var miCookie = HttpContext.Request.Cookies["Cookie_Inventario"];

            if (miCookie != null)
            {
                List<Usuario> listaUsuarios = _contextDB.Usuario.ToList();
                foreach (var user in listaUsuarios)
                {
                    if (miCookie == user.Correo)
                    {
                        return user.Correo;
                    }
                }
            }
            return "";
        }

        public IActionResult CerrarSesion()
        {
            string Correo = Cookies();
            HttpContext.Response.Cookies.Delete("Cookie_Inventario");
            return RedirectToAction("Index");
        }

        public void Initialize()
        {
            _contextDB.Database.EnsureCreated();

            if (_contextDB.Usuario.Any())
            {
                return;
            }

            var insertarUsuario = new Usuario[]
            {
                new Usuario {Nombre = "Rich", Contrasena = "1234", Correo = "ricardo_138@outlook.com", TipoUsuario = "Admin", DireccionImagen = "h", Cargo = "Administrador", Telefono = "5618984344", Ubicacion_Actual = ""}
            };
            var insertarEquipo = new Equipo[]
            {
                new Equipo {Tipo_Activo = "Laptop", Color = "Gris", Costo = 1, Estado = "Usado", Detalle = "Laptop", IMEI = "", Marca = "Lenovo", Modelo = "IdeaPad 3 14ITL05", No_Serie = "PF49JQPT", Ubicacion_Actual = "MCN", Id_Responsable = 1}
            };

            foreach (var u in insertarUsuario)
                _contextDB.Usuario.Add(u);
            _contextDB.SaveChanges();

            foreach (var u in insertarEquipo)
                _contextDB.Equipo.Add(u);
            _contextDB.SaveChanges();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
