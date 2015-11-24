using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models.Directorio
{
    public class ActualizarEmpresaViewModel
    {
        public Dir_Empresas empresa {
            get;
            set;
        }
        public List<Dir_Establecimientos> establecimientos {
            get;
            set;
        }
        public List<Glo_Comunas> Comunas
        {
            get;
            set;
        }
        public List<Glo_Provincias> Provincias
        {
            get;
            set;
        }
        public List<Glo_Estados> Estados
        {
            get;
            set;
        }
    }
    
}

