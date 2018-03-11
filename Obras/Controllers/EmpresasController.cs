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

            var model = db.dbEmpresa;
            IEnumerable<StatusViewModel> lista = Enum.GetValues(typeof(StatusEmpresa)).Cast<StatusEmpresa>().Select(t => new StatusViewModel
            {
                Id = ((int)t),
                Descripcion = t.ToString()
            });
            ViewData["Status"] = lista;
            return View(model);
        }
        
        public class StatusViewModel
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
        }
        public ActionResult getEmpresas([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<Empresa> Details = db.dbEmpresa;
            DataSourceResult result = Details.ToDataSourceResult(request, p => new Empresa
            {
                Id = p.Id,
                IdUsuario=p.IdUsuario,
                RegistroEdo = p.RegistroEdo,
                RepresLegal = p.RepresLegal,
                Tecnico = p.Tecnico,
                RFC = p.RFC,
                FechaRegistro = p.FechaRegistro,
                Estatus=p.Estatus
                

            });
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}