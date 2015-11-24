using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Excel = Microsoft.Office.Interop.Excel;
using BeyondThemes.BeyondAdmin.Models.Directorio;
using BeyondThemes.BeyondAdmin.Models;
using System.IO;






namespace BeyondThemes.BeyondAdmin.Controllers
{
    [Authorize(Roles = "Encuestador")]
    public class DirectorioController : Controller
    {
        // GET: Directorio
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Empresas()
        {
            return View();
        }
        public ActionResult Establecimientos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ImportarEmpresas(HttpPostedFileBase ExcelFile)
        {
            if (ExcelFile == null || ExcelFile.ContentLength == 0)
            {
                ViewBag.Error("Por favor ingrese un archivo de excel");
                return View("Empresas");
            }
            else
            {
                if (ExcelFile.FileName.EndsWith("xls") || ExcelFile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Uploads/" + ExcelFile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    ExcelFile.SaveAs(path);
                    // leer informacion desde archivo excel
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;

                    List<Dir_Empresas> ListaDeEmpresas = new List<Dir_Empresas>();
                    int contador = 0;
                    using (Entities db = new Entities())
                    {
                        for (int row = 3; row < range.Rows.Count; row++)
                        {
                            int rut = Convert.ToInt32(((Excel.Range)range.Cells[row, 1]).Text);
                            string dv = ((Excel.Range)range.Cells[row, 2]).Text;
                            // validacion con digito verificador
                            if (db.Dir_Empresas.Find(rut) == null)
                            {
                                Dir_Empresas emp = new Dir_Empresas();
                                emp.RutEmpresa = Convert.ToInt32(((Excel.Range)range.Cells[row, 1]).Text);
                                emp.DvEmpresa = ((Excel.Range)range.Cells[row, 2]).Text;
                                emp.RazonSocial = ((Excel.Range)range.Cells[row, 5]).Text;
                                emp.RepresentanteLegal = ((Excel.Range)range.Cells[row, 30]).Text;
                                emp.CodComuna = Convert.ToInt32(((Excel.Range)range.Cells[row, 19]).Text);
                                emp.IdEstado = 1;
                                // usar procedimientos almacenado para insertar lista de empresas
                                //var a = db.Pa_Cls_EmpresasDir_Insertar(emp.RutEmpresa, emp.CodComuna, emp.DvEmpresa, emp.RazonSocial, emp.RepresentanteLegal, emp.IdEstado);
                                db.Dir_Empresas.Add(emp);

                            }
                            contador++;
                        }
                        db.SaveChanges();
                    }
                    return View("Empresas");
                }
                else
                {
                    ViewBag.Error("El tipo de archivo  es incorrecto");
                }
            }
            return View();
        }

        public ActionResult ListaDeEmpresas(jQueryDataTableParamModel param)
        {
            using (Entities db = new Entities())
            {

                var allCompanies = db.Dir_Empresas.Include("Glo_Comunas").Include("Dir_Establecimientos").ToList();
                IEnumerable<Dir_Empresas> filteredCompanies = allCompanies;
                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    filteredCompanies = db.Dir_Empresas.ToList()
                             .Where(c => c.RazonSocial.Contains(param.sSearch.ToUpper())
                                         ||
                              c.RutEmpresa.ToString().Contains(param.sSearch.ToUpper()));
                }
                else
                {
                    filteredCompanies = allCompanies;
                }
                var isRutSortable = Convert.ToBoolean(Request["bSortable_0"]);
                var isRazonSocialSortable = Convert.ToBoolean(Request["bSortable_1"]);
                var isComunaSortable = Convert.ToBoolean(Request["bSortable_2"]);

                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                Func<Dir_Empresas, string> orderingFunction = (emp =>
                                        sortColumnIndex == 0 && isRutSortable ? Convert.ToString(emp.RutEmpresa) :
                                        sortColumnIndex == 2 && isComunaSortable ? Convert.ToString(emp.Glo_Comunas.NombreComuna) :
                                        sortColumnIndex == 1 && isRazonSocialSortable ? emp.Glo_Comunas.NombreComuna.ToString() :
                                        "");
                var sortDirection = Request["sSortDir_0"]; // asc or desc
                if (sortDirection == "asc")
                    filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
                else
                    filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);
                var displayedCompanies = filteredCompanies
                         .Skip(param.iDisplayStart)
                         .Take(param.iDisplayLength);
                var result = from c in displayedCompanies
                             select new[] { c.RutEmpresa.ToString(), c.RazonSocial.ToString(), c.Glo_Comunas.NombreComuna.ToString(), c.RepresentanteLegal.ToString(), c.Dir_Establecimientos.Count().ToString() };
                return Json(new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = allCompanies.Count(),
                    iTotalDisplayRecords = filteredCompanies.Count(),
                    aaData = result
                },
                            JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ListaDeEstablecimientos(jQueryDataTableParamModel param)
        {
            using (Entities db = new Entities())
            {

                var allCompanies = db.Dir_Establecimientos.Include("Glo_Comunas").Include("Dir_Empresas").ToList();
                IEnumerable<Dir_Establecimientos> filteredCompanies = allCompanies;
                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    filteredCompanies = db.Dir_Establecimientos.ToList()
                             .Where(c => c.NombreEstablecimiento.Contains(param.sSearch.ToUpper())
                                         ||
                              c.RolEstablecimiento.ToString().Contains(param.sSearch.ToUpper()));
                }
                else
                {
                    filteredCompanies = allCompanies;
                }
                var isRolSortable = Convert.ToBoolean(Request["bSortable_0"]);
                var isNombreEstablecimientoSortable = Convert.ToBoolean(Request["bSortable_1"]);
                var isComunaSortable = Convert.ToBoolean(Request["bSortable_2"]);

                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                Func<Dir_Establecimientos, string> orderingFunction = (emp =>
                                        sortColumnIndex == 0 && isRolSortable ? Convert.ToString(emp.RolEstablecimiento) :
                                        sortColumnIndex == 2 && isComunaSortable ? Convert.ToString(emp.Glo_Comunas.NombreComuna) :
                                        sortColumnIndex == 1 && isNombreEstablecimientoSortable ? emp.NombreEstablecimiento.ToString() :
                                        "");
                var sortDirection = Request["sSortDir_0"]; // asc or desc
                if (sortDirection == "asc")
                    filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
                else
                    filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);
                var displayedCompanies = filteredCompanies
                         .Skip(param.iDisplayStart)
                         .Take(param.iDisplayLength);
                var result = from c in displayedCompanies
                             select new[] { c.RolEstablecimiento.ToString(), c.RutEmpresa.ToString(), c.NombreEstablecimiento.ToString(), c.NombreEstablecimiento.ToString(), c.Glo_Comunas.NombreComuna.ToString() };
                return Json(new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = allCompanies.Count(),
                    iTotalDisplayRecords = filteredCompanies.Count(),
                    aaData = result
                },
                            JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ActualizarEmpresa(int IdEmpresa)
        {
            ActualizarEmpresaViewModel vm = new ActualizarEmpresaViewModel();
            using (Entities db = new Entities())
            {
                vm.empresa = db.Dir_Empresas.Find(IdEmpresa);
                vm.establecimientos = db.Dir_Establecimientos.Include("Glo_Estados").Include("Dir_Empresas").Where(x => x.RutEmpresa == IdEmpresa).ToList();
                var provincia = vm.empresa.Glo_Comunas.CodProvincia;
                vm.Comunas = db.Glo_Comunas.Where(x => x.CodProvincia == provincia).ToList();
                vm.Provincias = db.Glo_Provincias.Where(x => x.CodRegion == 8).ToList();
                vm.Estados = db.Glo_Estados.ToList();
            }

            return View(vm);
        }

        public ActionResult ParcialEstablecimientosPorEmpresa(int EmpresaId = -1)
        {

            ParcialEstablecimientosPorEmpresaViewModel vm = new ParcialEstablecimientosPorEmpresaViewModel();
            
            using (Entities db = new Entities())
            {
                var establecimientos = db.Dir_Establecimientos.Where(x => x.RutEmpresa == EmpresaId).ToList();

                List<DetalleEstablecimiento> lista = new List<DetalleEstablecimiento>();
                vm.estados = db.Glo_Estados.ToList();
                vm.comunas = db.Glo_Comunas.ToList();
                vm.provincias = db.Glo_Provincias.Where(x => x.CodRegion == 8).ToList();
                vm.tipovias = db.Glo_TipoVia.ToList();

                vm.clases = db.Glo_Clase.ToList();
                vm.grupos = db.Glo_Grupo.ToList();
                vm.divisiones = db.Glo_Division.ToList();
                vm.secciones = db.Glo_Seccion.ToList();

               foreach(Dir_Establecimientos establecimiento in establecimientos)
                {
                    DetalleEstablecimiento item = new DetalleEstablecimiento();
                    item.establecimiento = establecimiento;
                    item.empresa = establecimiento.Dir_Empresas;
                    item.comuna = establecimiento.Glo_Comunas;
                    item.informante = establecimiento.Ges_Informante;
                    item.estado = establecimiento.Glo_Estados;
                    item.georeferencia = establecimiento.Ges_Georreferencia;
                    item.tipovia = establecimiento.Glo_TipoVia;
                    item.actividad = establecimiento.Glo_Clase;
                    DetalleActividad detalle = new DetalleActividad();

                    detalle.clase = establecimiento.Glo_Clase.IdActividad;
                    detalle.grupo = establecimiento.Glo_Clase.Glo_Grupo.IdGrupo;
                    detalle.division = establecimiento.Glo_Clase.Glo_Grupo.Glo_Division.IdDivision;
                    detalle.seccion = establecimiento.Glo_Clase.Glo_Grupo.Glo_Division.Glo_Seccion.IdSeccion;
                    item.detalleActividad = detalle;
                    
                
                    lista.Add(item);
                }
                vm.Establecimientos = lista;
            }
            return View(vm);
        }

        public ActionResult ParcialNuevaEmpresa()
        {
            ParcialNuevaEmpresaViewModel vm = new ParcialNuevaEmpresaViewModel();
            using (Entities db = new Entities()) {
                vm.provincias = db.Glo_Provincias.Where(x => x.CodRegion == 8).ToList();
                vm.estados = db.Glo_Estados.ToList();
            }

                return View(vm);
        }
        [HttpPost()]
        public ActionResult NuevaEmpresa(Dir_Empresas empresa)
        {
            using (Entities db = new Entities())
            {
                if (ModelState.IsValid)
                {
                    if (db.Dir_Empresas.Find(empresa.RutEmpresa) == null)
                    {
                        try
                        {
                            db.Dir_Empresas.Add(empresa);
                            db.SaveChanges();
                        }
                        catch (Exception e) {
                            return Json(e.Message);
                        }
                       
                        return Json(1);
                    }
                    else
                        return Json(0);
                   
                }
            }
            return Json(0);
        }
        [HttpPost()]
        public ActionResult ActualizarDatosEmpresa(Dir_Empresas empresa)
        {
            using (Entities db = new Entities()) {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Entry(empresa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception e) {
                        return Json(e.Message);
                    }
                    
                    return Json(1);
                }
            }
            return Json(0);
        }

        [HttpPost()]
        public ActionResult ActualizarDatosEstablecimiento(Dir_Establecimientos establecimiento,Ges_Informante informante, Ges_Georreferencia georeferencia)
        {
            using (Entities db = new Entities())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        establecimiento.FechaActualizacion = DateTime.Now;                            
                        db.Entry(establecimiento).State = EntityState.Modified;
                        // falta validar cuando no exista informante ni georeferencia, asi debe agregar un nuevo registro(ambos casos)
                        //db.Entry(informante).State = EntityState.Modified;
                        //georeferencia.Latitud = Convert.ToString(georeferencia.Latitud);
                        //georeferencia.Longitud = Convert.ToString(georeferencia.Longitud);
                        //georeferencia.FechaGeorreferencia = DateTime.Now;
                        //db.Entry(georeferencia).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return Json(e.Message);
                    }
                    return Json(1);
                }
            }
            return Json(0);
        }

        [HttpPost()]
        public ActionResult ActualizarGeoreferenciatosEstablecimiento(Ges_Georreferencia georeferencia)
        {
            using (Entities db = new Entities())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                       
                        georeferencia.Latitud = Convert.ToString(georeferencia.Latitud);
                        georeferencia.Longitud = Convert.ToString(georeferencia.Longitud);
                        georeferencia.FechaGeorreferencia = DateTime.UtcNow;
                        db.Entry(georeferencia).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return Json(e.Message);
                    }
                    return Json(1);
                }
            }
            return Json(0);
        }

        [HttpPost()]
        public ActionResult NuevaGeoreferenciatosEstablecimiento(Ges_Georreferencia georeferencia)
        {
            using (Entities db = new Entities())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        georeferencia.Latitud = Convert.ToString(georeferencia.Latitud);
                        georeferencia.Longitud = Convert.ToString(georeferencia.Longitud);
                        georeferencia.FechaGeorreferencia = DateTime.UtcNow;
                        db.Entry(georeferencia).State = EntityState.Added;
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return Json(e.Message);
                    }
                    return Json(1);
                }
            }
            return Json(0);
        }

        public ActionResult ParcialNuevoInformante(int RolEstablecimiento)
        {
            ParcialNuevoInformanteViewModel vm = new ParcialNuevoInformanteViewModel();
            vm.RolEstablecimiento = RolEstablecimiento;
            return View(vm);
        }

        [HttpPost()]
        public ActionResult NuevoInformante(Ges_Informante informante)
        {
            using (Entities db = new Entities())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Entry(informante).State = EntityState.Added;
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return Json(e.Message);
                    }
                    return Json(1);
                }
            }
            return Json(0);
        }

    }
}