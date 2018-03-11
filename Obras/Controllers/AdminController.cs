using LinqToExcel;
using Obras.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obras.Controllers
{
    public class AdminController : Controller
    {
        private AppplicationDBContext db = new AppplicationDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmpresasExcel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmpresasExcel(HttpPostedFileBase FileUpload)
        {
            if (FileUpload != null)
            {
                if (FileUpload.ContentType == "applicaction/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string fileName = FileUpload.FileName;
                    string targethPath = Server.MapPath("~/Doc/");
                    string PathToExcel = targethPath + fileName;
                    FileUpload.SaveAs(targethPath + fileName);
                    var connection = "";
                    if (fileName.EndsWith(".xls"))
                    {
                        connection = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", PathToExcel);
                    }
                    else if (fileName.EndsWith(".xlsx"))
                    {
                        connection = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties=\"Excel 12.0 Xml; HDR=YES;IMEX=1\";", PathToExcel);
                    }
                    var adapter = new OleDbDataAdapter("SELECT * from [Hoja1$]", connection);
                    var ds = new DataSet();
                    adapter.Fill(ds, "ExcelTable");
                    DataTable dtable = ds.Tables["ExcelTable"];
                    var excelFile = new ExcelQueryFactory(PathToExcel);
                    var rows = from c in excelFile.WorksheetNoHeader("Hoja1") select c;
                    List<Empresa> lista = new List<Empresa>();
                    foreach (var row in rows)
                    {
                        try
                        {
                            if (row[0] != "" && row[2] != "")
                            {
                                Empresa aux = new Empresa { CapitalContable = Convert.ToDouble(row[5].ToString()), CapitalSocial = Convert.ToDouble(row[4].ToString()), CMIC = row[6].ToString(), CNEC = row[7].ToString(), FechaRegistro = Convert.ToDateTime(row[8].ToString()), NumIMSS = row[3].ToString(), RepresLegal = row[1].ToString(), RFC = row[0].ToString(), Tecnico = row[2].ToString() };
                                lista.Add(aux);
                            }
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Error = ex.Message;
                            return View("Error");
                        }
                    }
                    db.dbEmpresa.AddRange(lista);
                    return View("Register");
                }
                else
                {
                    ViewBag.Error = "El archivo que intenta subir, no tiene el formato requerido (.xls o .xlsx)";
                }
            }
            else
            {
                ViewBag.Error = "No se encontró el Archivo";
            }
            return View("Error");
        }
        public ActionResult Usuarios()
        {
            return View();
        }
        public ActionResult Roles()
        {
            return View();
        }
    }
}