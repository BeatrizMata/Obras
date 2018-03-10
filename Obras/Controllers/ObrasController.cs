using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Obras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obras.Controllers
{
    [Authorize]
    public class ObrasController : Controller
    {
        // GET: Obras
        private AppplicationDBContext db = new AppplicationDBContext();

        public ActionResult Index()
        {
            var model = db.dbObra.ToList();
            IEnumerable <StatusViewModel> lista = Enum.GetValues(typeof(StatusObra)).Cast<StatusObra>().Select(t => new StatusViewModel
            {
                Id = ((int)t),
                Descripcion = t.ToString()
            });
            ViewData["Status"]=lista;
            return View(model);
        }
        public class StatusViewModel
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
        }
        public ActionResult getObras([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<Obra> Details = db.dbObra;
            DataSourceResult result = Details.ToDataSourceResult(request, p => new Obra
            {
                Id = p.Id,
                Descripcion = p.Descripcion,
                Convenio = p.Convenio,
                Ubicacion = p.Ubicacion,
                Estatus = p.Estatus


            });
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_CreateObra([DataSourceRequest] DataSourceRequest request, Obra obra)
        {
            db.dbObra.Add(obra);
            db.SaveChanges();
            return Json(new[] { obra }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInLine_Obra([DataSourceRequest] DataSourceRequest request, Obra obra)
        {
            db.Entry(obra).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new[] { obra }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingCatalgo_DestroyObra([DataSourceRequest] DataSourceRequest request, Obra obra)
        {
            if (obra != null)
            {
                db.Entry(obra).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return Json(new[] { obra }.ToDataSourceResult(request, ModelState));
        }

    }
}