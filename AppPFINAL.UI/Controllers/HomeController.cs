using AppPFINAL.BD;
using AppPFINAL.BD.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPFINAL.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string Contrasenna, string Cedula)
        {
          
            int Uced = Convert.ToInt32(Cedula);
            
            var aux = GestionBD.SelectUsuario().Where(x => Uced == x.Cedula && Contrasenna == x.Contrasenna).FirstOrDefault();


            if (aux == null) {

                return RedirectToAction("Index", "Home");
            }

                if (aux != null)

                {
                if(aux.Rol== "B")
                {
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    return RedirectToAction("Index", "Administrador");
                }
                
            }

            return RedirectToAction("Index","Home");

        }
    }
}