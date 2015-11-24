using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeyondThemes.BeyondAdmin.Models.Widget;
using BeyondThemes.BeyondAdmin.Models;
namespace BeyondThemes.BeyondAdmin.Controllers
{
    public class WidgetController : Controller
    {
        // GET: Widget
        public JsonResult EmpresaExiste(int RutEmpresa)
        {
            using (Entities db = new Entities()) {

                if (db.Dir_Empresas.Find(RutEmpresa) == null)
                {
                    return Json(false);
                }
                else {
                    return Json(true);
                }
            }  
        }

        public ActionResult ParcialComunas(int CodProvincia)
        {
            ParcialComunasViewModel vm = new ParcialComunasViewModel();
            using (Entities db = new Entities()) {
                vm.comunas = db.Glo_Comunas.Where(x => x.CodProvincia == CodProvincia).ToList();
            }
            return View(vm);
        }

     


        public ActionResult ParcialClases(int IdGrupo, int establecimiento)
        {
            ParcialClasesViewModel vm = new ParcialClasesViewModel();
            vm.establecimiento = establecimiento;
            using (Entities db = new Entities())
            {
                vm.clases = db.Glo_Clase.Where(x => x.IdGrupo == IdGrupo).ToList();
            }
            return View(vm);
        }

        public ActionResult ParcialGrupos(int IdDivision, int establecimiento)
        {
            ParcialGruposViewModel vm = new ParcialGruposViewModel();
            vm.establecimiento = establecimiento;
            using (Entities db = new Entities())
            {
                vm.grupos = db.Glo_Grupo.Where(x => x.IdDivision == IdDivision).ToList();
            }
            return View(vm);
        }
        public ActionResult ParcialDivisiones(string IdSeccion, int establecimiento)
        {
            ParcialDivisionesViewModel vm = new ParcialDivisionesViewModel();
            vm.establecimiento = establecimiento;
            using (Entities db = new Entities())
            {
                vm.divisiones = db.Glo_Division.Where(x => x.IdSeccion == IdSeccion).ToList();
            }
            return View(vm);
        }

         public ActionResult ParcialObtenerMuestra(int IdTipoEncuesta)
         {
            ParcialObtenerMuestraViewModel vm = new ParcialObtenerMuestraViewModel();
            using (Entities db = new Entities()) {
                var encuesta = db.Ges_Encuestas.Where(x => x.IdTipoEncuesta == IdTipoEncuesta).Max(y => y.IdEncuesta);
                vm.Muestras = db.Ges_Muestra.Include("Dir_Establecimientos").Where(x => x.IdEncuesta == encuesta).ToList();

            }
               return View(vm);
        }
    }
}