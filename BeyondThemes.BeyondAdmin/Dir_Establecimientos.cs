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
    
    public partial class Dir_Establecimientos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dir_Establecimientos()
        {
            this.Ges_Muestra = new HashSet<Ges_Muestra>();
        }
    
        public int RolEstablecimiento { get; set; }
        public int CodTipoVia { get; set; }
        public int IdActividad { get; set; }
        public int IdEstado { get; set; }
        public int CodComuna { get; set; }
        public int RutEmpresa { get; set; }
        public string DvEstablecimiento { get; set; }
        public string DireccionEstablecimiento { get; set; }
        public string NumeroEstablecimiento { get; set; }
        public string RestoDireccion { get; set; }
        public string CodigoArea1 { get; set; }
        public string Telefono1 { get; set; }
        public string CodigoArea2 { get; set; }
        public string Telefono2 { get; set; }
        public string CodigoArea3 { get; set; }
        public string Telefono3 { get; set; }
        public string CorreoElectronico { get; set; }
        public string SitioWeb { get; set; }
        public string Casilla { get; set; }
        public string Observacion { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public string NombreEstablecimiento { get; set; }
    
        public virtual Dir_Empresas Dir_Empresas { get; set; }
        public virtual Glo_Clase Glo_Clase { get; set; }
        public virtual Glo_Comunas Glo_Comunas { get; set; }
        public virtual Glo_Estados Glo_Estados { get; set; }
        public virtual Glo_TipoVia Glo_TipoVia { get; set; }
        public virtual Ges_Georreferencia Ges_Georreferencia { get; set; }
        public virtual Ges_Informante Ges_Informante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ges_Muestra> Ges_Muestra { get; set; }
    }
}
