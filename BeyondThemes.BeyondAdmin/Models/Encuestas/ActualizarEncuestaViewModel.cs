using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models.Encuestas
{
    public class ActualizarEncuestaViewModel
    {
        public Ges_Encuestas Encuesta
        {
            get;
            set;
        }
        public List< Glo_EstadoEncuesta > EstadosEncuestas
        {
            get;
            set;
        }
        public List< Glo_TipoEncuesta> TiposEncuentas
        {
            get;
            set;

        }
      

        public List<DetalleActividad> ActividadesEncuesta
        {
            get;
            set;
        }
        public List<Glo_Clase> clases
        {
            get;
            set;
        }
        public List<Glo_Grupo> grupos
        {
            get;
            set;
        }
        public List<Glo_Division> divisiones
        {
            get;
            set;
        }
        public List<Glo_Seccion> secciones
        {
            get;
            set;
        }

        public class DetalleActividad
        {
            public int id;
            public string seccion;
            public int division;
            public int grupo;
            public int clase;

        }
    }
}