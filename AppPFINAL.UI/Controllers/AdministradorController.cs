using AppPFINAL.BD.Interface;
using AppPFINAL.BD.Modelo;
using AppPFINAL.BD.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppPFINAL.UI.Controllers
{
    public class AdministradorController : Controller
    {
        private PPFINALEntities database = new PPFINALEntities();
        private readonly IGestorBD _oGestorBD;
        public AdministradorController()
        {
            _oGestorBD = new GestorBD();
        }

        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerUsuarios()
        {
            IEnumerable<Usuario> ListaUsuarios = _oGestorBD.ListadoUsuario();
            return View(ListaUsuarios);
        }

        public ActionResult MostrarUsuario()
        {
            return View();
        }

        public ActionResult EditarUsuario(int id)
        {
            Usuario aux = _oGestorBD.ListadoUsuario().Where(x => x.Cedula == id).FirstOrDefault();
            return View(aux);
        }

        public ActionResult ModificarUsuario(Usuario objUsuario) 
        {
            int registros = _oGestorBD.ActualizarUsuario(objUsuario);
            return RedirectToAction("VerUsuarios");
        }

        public ActionResult RegistrarUsuario(Usuario objUsuario)
        {
            int registros = _oGestorBD.CrearUsuario(objUsuario);
            return RedirectToAction("Index", "Administrador");
        }

        public ActionResult EliminarUsuario(int id) 
        {
            int registro = _oGestorBD.BorrarUsuario(id);
            return RedirectToAction("Index");
        }

        public ActionResult SolicitudesTarjetas()
        {
            IEnumerable<Tarjeta> listadoTarjetas = _oGestorBD.ListadoTarjeta();

            return View(listadoTarjetas);
        }

        //GET: Admin/Edit
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta objTarjeta = await database.Tarjeta.FindAsync(id);
            if (objTarjeta == null)
            {
                return HttpNotFound();

            }
            ViewBag.Cedula = new SelectList(database.Usuario, "Cedula", "Cedula", objTarjeta.Cedula);
            return View(objTarjeta);


        }

        //Post: Admin/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NumeroTarjeta,TipoTarjeta,LimiteCredito,MontoExtra,FechaActivacion,Origen,EstadoTarjeta,TipoInteres,Cedula")] Tarjeta objTarjeta)
        {
            if (ModelState.IsValid)
            {
                database.Entry(objTarjeta).State = EntityState.Modified;
                await database.SaveChangesAsync();
                return RedirectToAction("SolicitudesTarjetas");

            }
            //se puede quitar todo depende de la FK
            ViewBag.Cedula = new SelectList(database.Usuario, "Cedula", "Cedula", objTarjeta.Cedula);
            return View(objTarjeta);
        }
    }

}
