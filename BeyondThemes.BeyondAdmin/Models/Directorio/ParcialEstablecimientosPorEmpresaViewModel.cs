using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models.Directorio
{
    public class ParcialEstablecimientosPorEmpresaViewModel
    {
        public List<DetalleEstablecimiento> Establecimientos
        {
            get;
            set;
        }
        public List<Glo_Comunas>comunas
        {
            get;
            set;
        }
        public List<Glo_Provincias> provincias
        {
            get;
            set;
        }
        public List<Glo_Estados> estados
        {
            get;
            set;
        }
        public List<Glo_TipoVia> tipovias {
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
    }


    public class DetalleEstablecimiento
    {
        public Dir_Establecimientos establecimiento{
            get;
            set;
            }
        public Dir_Empresas empresa
        {
            get;
            set;
        }

        public Glo_Comunas comuna
        {
            get;
            set;
        }

        public Glo_Estados estado
        {
            get;
            set;
        }

        public Ges_Informante informante
        {
            get;
            set;
        }
        public Ges_Georreferencia georeferencia
        {
            get;
            set;
        }
        public Glo_TipoVia tipovia {
            get;
            set;
        }
        public Glo_Clase actividad {
            get;
            set;
        }
        public DetalleActividad detalleActividad {
            get;
            set;
        }
    }

    public class DetalleActividad {
       public string seccion;
       public int division;
       public int grupo;
       public int clase;
     
    }
}