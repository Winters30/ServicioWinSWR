//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceSWR
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIOS()
        {
            this.HISTORIAL = new HashSet<HISTORIAL>();
            this.RUTAS = new HashSet<RUTAS>();
            this.USUARIO_CIUDADES = new HashSet<USUARIO_CIUDADES>();
        }
    
        public System.Guid ID { get; set; }
        public string NOMBRE { get; set; }
        public bool ACTIVO { get; set; }
        public string EMAIL { get; set; }
        public int IDROL { get; set; }
        public Nullable<int> IDEMPRESA { get; set; }
    
        public virtual EMPRESAS EMPRESAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL> HISTORIAL { get; set; }
        public virtual ROLES ROLES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RUTAS> RUTAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO_CIUDADES> USUARIO_CIUDADES { get; set; }
    }
}
