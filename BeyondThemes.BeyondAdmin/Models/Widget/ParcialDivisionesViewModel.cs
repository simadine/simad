using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models.Widget
{
    public class ParcialDivisionesViewModel
    {

        public List<Glo_Division> divisiones
        {
            get;
            set;
        }

        public int establecimiento
        {
            get;
            set;
        }
    }
}