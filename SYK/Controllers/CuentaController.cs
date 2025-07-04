using SYK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CRUD1.Controllers
{
    public class CuentaController : Controller
    {
        private readonly SykContext db;

        public CuentaController(SykContext context)
        {
            db = context;
        }

        // GET: /Cuenta/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Cuenta/Login
        [HttpPost]
        public IActionResult Login(string correo, string password)
        {
            var usuario = db.Usuarios.FirstOrDefault(c => c.Correo == correo && c.Password == password);

            if (usuario != null)
            {
                HttpContext.Session.SetString("A", usuario.Nombre);
                return RedirectToAction("Index", "Home");
            }


            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
