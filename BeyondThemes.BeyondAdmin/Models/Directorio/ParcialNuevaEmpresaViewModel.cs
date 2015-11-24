using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models.Directorio
{
    public class ParcialNuevaEmpresaViewModel
    {
       public List<Glo_Provincias> provincias {
            get;
            set;
        }
        public List<Glo_Estados> estados {
            get;
            set;
        }
    }
}