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
    
    public partial class Dir_Empresas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dir_Empresas()
        {
            this.Dir_Establecimientos = new HashSet<Dir_Establecimientos>();
            this.Dir_EstablecimientosTemporales = new HashSet<Dir_EstablecimientosTemporales>();
        }
    
        public int RutEmpresa { get; set; }
        public int CodComuna { get; set; }
        public int IdEstado { get; set; }
        public string DvEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string RepresentanteLegal { get; set; }
    
        public virtual Glo_Comunas Glo_Comunas { get; set; }
        public virtual Glo_Estados Glo_Estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dir_Establecimientos> Dir_Establecimientos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dir_EstablecimientosTemporales> Dir_EstablecimientosTemporales { get; set; }
    }
}
