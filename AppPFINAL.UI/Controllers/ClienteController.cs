using AppPFINAL.BD.Interface;
using AppPFINAL.BD.Modelo;
using AppPFINAL.BD.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppPFINAL.UI.Controllers
{
    public class ClienteController : Controller
    {
        private PPFINALEntities database = new PPFINALEntities();
        private readonly IGestorBD _oGestorBD;
        public ClienteController()
        {
            _oGestorBD = new GestorBD();
        }
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }


        //GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.cedula = new SelectList(database.Usuario, "Cedula", "Cedula");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        //
        public async Task<ActionResult> Create([Bind(Include = "NumeroTarjeta,TipoTarjeta,LimiteCredito,MontoExtra,FechaActivacion,Origen,TipoInteres,Cedula")] Tarjeta objtarjeta)
        {
            if (ModelState.IsValid)
            {
                database.Tarjeta.Add(objtarjeta);
                await database.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cedula = new SelectList(database.Usuario, "Cedula", "Cedula", objtarjeta.Cedula);
            return View(objtarjeta);
        }

        public ActionResult Consultar()
        {
            IEnumerable<Tarjeta> listadoTarjetas = _oGestorBD.ListadoTarjeta();

            return View(listadoTarjetas);
        }

    }
}