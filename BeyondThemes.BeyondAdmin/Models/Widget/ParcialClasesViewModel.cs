using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models.Widget
{
    public class ParcialClasesViewModel
    {
        public List<Glo_Clase> clases
        {
            get;
            set;
        }
        public int establecimiento;
    }
}