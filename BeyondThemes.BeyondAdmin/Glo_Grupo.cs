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
    
    public partial class Glo_Grupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Glo_Grupo()
        {
            this.Glo_Clase = new HashSet<Glo_Clase>();
        }
    
        public int IdGrupo { get; set; }
        public int IdDivision { get; set; }
        public string GlosaGrupo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Glo_Clase> Glo_Clase { get; set; }
        public virtual Glo_Division Glo_Division { get; set; }
    }
}