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
    
    public partial class Ges_Encuestas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ges_Encuestas()
        {
            this.Ges_EncuestaAE = new HashSet<Ges_EncuestaAE>();
            this.Ges_Muestra = new HashSet<Ges_Muestra>();
        }
    
        public int IdEncuesta { get; set; }
        public int IdEstadoEncuesta { get; set; }
        public string NombreEncuesta { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaTermino { get; set; }
        public Nullable<int> IdTipoEncuesta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ges_EncuestaAE> Ges_EncuestaAE { get; set; }
        public virtual Glo_EstadoEncuesta Glo_EstadoEncuesta { get; set; }
        public virtual Glo_TipoEncuesta Glo_TipoEncuesta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ges_Muestra> Ges_Muestra { get; set; }
    }
}
