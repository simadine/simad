//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeyondThemes.BeyondAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log_Acceso
    {
        public int IdLogAcceso { get; set; }
        public string Login { get; set; }
        public Nullable<System.DateTime> FechaLogAcceso { get; set; }
        public string IP { get; set; }
        public string VerNavegador { get; set; }
    
        public virtual Ges_Usuario Ges_Usuario { get; set; }
    }
}
