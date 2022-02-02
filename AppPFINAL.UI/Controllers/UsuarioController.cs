using AppPFINAL.BD.Interface;
using AppPFINAL.BD.Modelo;
using AppPFINAL.BD.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppPFINAL.UI.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IGestorBD _oGestorBD;
        public UsuarioController()
        {
            _oGestorBD = new GestorBD();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }


        //Dibuja el formulario como tal
        public ActionResult MostrarUsuario()
        {
            return View();
        }

        //Registramos el articulo
        public ActionResult RegistrarUsuario(Usuario objUsuario)
        {
            
            int registros = _oGestorBD.CrearUsuario(objUsuario);
            return RedirectToAction("Index", "Home");
        }
    }
}