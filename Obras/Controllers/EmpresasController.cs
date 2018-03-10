using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Obras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obras.Controllers
{
    public class EmpresasController : Controller
    {
        private AppplicationDBContext db = new AppplicationDBContext();
        // GET: Empresas
        public ActionResult Index()
        {

            var model = db.dbEmpresa.ToList();
            return View(model);
        }
        public ActionResult getEmpresas([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<Empresa> Details = db.dbEmpresa;
            DataSourceResult result = Details.ToDataSourceResult(request, p => new Empresa
            {
                IdEmpresa = p.IdEmpresa,
                //incluir el nombre de la tabla Usuarios
                RegistroEdo = p.RegistroEdo,
                RepresLegal = p.RepresLegal,
                Tecnico = p.Tecnico,
                RFC = p.RFC,
                FechaRegistro = p.FechaRegistro

            });
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}