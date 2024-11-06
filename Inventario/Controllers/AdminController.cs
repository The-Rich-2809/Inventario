using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    public class AdminController : Controller
    {
        private readonly Inventario_DB _contextDB;
        public static int Id { get; set; }
        public static string Nombre {  get; set; } = string.Empty;

        public AdminController(Inventario_DB contextDB)
        {
            _contextDB = contextDB;
        }

        public bool Cookies()
        {
            var miCookie = HttpContext.Request.Cookies["Cookie_Inventario"];

            if (miCookie != null)
            {
                List<Usuario> listaUsuarios = _contextDB.Usuario.ToList();
                foreach (var user in listaUsuarios)
                {
                    if (miCookie == user.Correo)
                    {
                        user.Id = Id;
                        user.Nombre = Nombre;
                        return true;
                    }
                }
            }
            return false;
        }

        public IActionResult Index()
        {
            if(Cookies())
            {
                List<Usuario> listUsuarios = _contextDB.Usuario.ToList();
                List<Equipo> listEquipo = _contextDB.Equipo.ToList();
                var viewmodel = new InventarioViewModel
                {
                    Equipos = listEquipo,
                    Usuarios = listUsuarios
                };
                return View(viewmodel);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult Usuarios()
        {
            if(Cookies())
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
