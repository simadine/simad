using BeyondThemes.BeyondAdmin.Models;
using BeyondThemes.BeyondAdmin.Models.Encuestas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeyondThemes.BeyondAdmin.Controllers
{
    [Authorize(Roles = "Encuestador")]
    public class EncuestasController : Controller
    {
        // GET: Encuestas
        public ActionResult Encuestas()
        {
            return View();
        }

        public ActionResult ListaDeEncuestas(jQueryDataTableParamModel param)
        {
            using (Entities db = new Entities())
            {

                var allCompanies = db.Ges_Encuestas.Include("Glo_EstadoEncuesta").Include("Ges_Muestra").Include("Glo_TipoEncuesta").ToList();
                IEnumerable<Ges_Encuestas> filteredCompanies = allCompanies;
                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    filteredCompanies = db.Ges_Encuestas.ToList()
                             .Where(c => c.NombreEncuesta.Contains(param.sSearch.ToUpper())
                                         ||
                              c.IdEncuesta.ToString().Contains(param.sSearch.ToUpper()));
                }
                else
                {
                    filteredCompanies = allCompanies;
                }
                var isIdSortable = Convert.ToBoolean(Request["bSortable_0"]);
                var isEstadoSorteable = Convert.ToBoolean(Request["bSortable_2"]);
                var isNombreEncuestaSortable = Convert.ToBoolean(Request["bSortable_1"]);

                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                Func<Ges_Encuestas, string> orderingFunction = (emp =>
                                        sortColumnIndex == 0 && isIdSortable ? Convert.ToString(emp.IdEncuesta) :
                                        sortColumnIndex == 1 && isNombreEncuestaSortable ? Convert.ToString(emp.NombreEncuesta) :
                                        sortColumnIndex == 2 && isEstadoSorteable ? emp.Glo_EstadoEncuesta.GlosaEncuestaEstado.ToString() :
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
                             select new[] { c.IdEncuesta.ToString(), c.NombreEncuesta.ToString(), c.Glo_EstadoEncuesta.GlosaEncuestaEstado.ToString(), c.FechaInicio.ToString(), c.Glo_TipoEncuesta.GlosaTipoEncuesta.ToString(), c.Ges_Muestra.Count().ToString() };
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
        public ActionResult ActualizarEncuesta(int IdEncuesta)
        {
            ActualizarEncuestaViewModel vm = new ActualizarEncuestaViewModel();
            using (Entities db = new Entities()) {
                vm.Encuesta = db.Ges_Encuestas.Find(IdEncuesta);
                vm.TiposEncuentas = db.Glo_TipoEncuesta.ToList();
                vm.EstadosEncuestas = db.Glo_EstadoEncuesta.ToList();
                
                vm.clases = db.Glo_Clase.ToList();
                vm.grupos = db.Glo_Grupo.ToList();
                vm.divisiones = db.Glo_Division.ToList();
                vm.secciones = db.Glo_Seccion.ToList();
            }
            return View(vm);
        }
        [HttpPost()]
        public ActionResult ActualizarDatosEncuesta(Ges_Encuestas Encuesta)
        {
            using (Entities db = new Entities())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Entry(Encuesta).State = EntityState.Modified;
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

        public ActionResult Muestra(jQueryDataTableParamModel param, int IdEncuesta)
        {
            using (Entities db = new Entities())
            {

                var allCompanies = db.Ges_Muestra.Include("Dir_Establecimientos").Include("Ges_Encuestas").Where(x => x.IdEncuesta == IdEncuesta).ToList();
                IEnumerable<Ges_Muestra> filteredCompanies = allCompanies;
                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    filteredCompanies = db.Ges_Muestra.Include("Dir_Establecimientos").Include("Ges_Encuestas").Where(x => x.IdEncuesta == IdEncuesta).ToList()
                           .Where(c => c.Dir_Establecimientos.NombreEstablecimiento.Contains(param.sSearch.ToUpper()));
                }
                else
                {
                    filteredCompanies = allCompanies;
                }
                var isNombreEstablecimientoSortable = Convert.ToBoolean(Request["bSortable_0"]);
                var isFechaRecepcionSortable = Convert.ToBoolean(Request["bSortable_1"]);
                var isRolSortable = Convert.ToBoolean(Request["bSortable_2"]);

                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                Func<Ges_Muestra, string> orderingFunction = (emp =>
                                        sortColumnIndex == 0 && isNombreEstablecimientoSortable ? Convert.ToString(emp.Dir_Establecimientos.NombreEstablecimiento) :
                                        sortColumnIndex == 2 && isRolSortable ? Convert.ToString(emp.RolEstablecimiento.ToString()) :
                                        sortColumnIndex == 1 && isFechaRecepcionSortable ? emp.FechaRecepcion.ToString() :
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
                             select new[] { c.Dir_Establecimientos.NombreEstablecimiento.ToString(), Convert.ToString(c.FechaRecepcion.ToString()), c.IdEncuesta.ToString(), "observacion", c.IdEncuesta.ToString() };
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

        public ActionResult ParcialNuevaEncuesta()
        {
            ParcialNuevaEncuestaViewModel vm = new ParcialNuevaEncuestaViewModel();
            using (Entities db = new Entities())
            {
                vm.TipoEncuestas = db.Glo_TipoEncuesta.ToList();
            }
            return View(vm);
        }
        [HttpPost()]
        public ActionResult NuevaEncuesta(Ges_Encuestas encuesta)
        {
            using (Entities db = new Entities())
            {
                int id = 0;
                if (ModelState.IsValid)
                {
                    try
                    {
                        Ges_Encuestas Enc = new Ges_Encuestas();
                        Enc.IdEstadoEncuesta = 1;// hay que crear los enums
                        Enc.IdTipoEncuesta = encuesta.IdTipoEncuesta;
                        Enc.FechaInicio = encuesta.FechaInicio;
                        Enc.FechaTermino = encuesta.FechaTermino;
                        Enc.NombreEncuesta = encuesta.NombreEncuesta.ToUpper();
                        db.Ges_Encuestas.Add(Enc);
                        db.SaveChanges();
                        id = Enc.IdEncuesta;
                    }
                    catch (Exception e)
                    {
                        return Json(e.Message);
                    }
                    return Json(id);
                }
            }
            return Json(0);
        }

        public JsonResult GuardarMuestraAnterior(List<int> values, string IdEncuesta) {
            using (Entities db = new Entities()) {

                int id = Convert.ToInt32(IdEncuesta);
                var Encuesta = db.Ges_Muestra.Where(x => x.IdEncuesta == id).ToList();
                if(Encuesta.Count() > 0) {
                    return Json(2);
                }
                else
                {
                    if (values != null)
                    {
                        foreach (var item in values)
                        {
                            Ges_Muestra muestra = new Ges_Muestra();
                            try
                            {
                                muestra.RolEstablecimiento = item;
                                muestra.IdEncuesta = id;
                                db.Ges_Muestra.Add(muestra);
                                db.SaveChanges();
                            }
                            catch (Exception e) {
                                Json(e.Message);
                            }
                           
                        }
                        return Json(1);
                    }
                    else {
                        return Json(3);
                    }
                }
            }
        }



    
    }
}