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
    
    public partial class CIUDADES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CIUDADES()
        {
            this.CIUDADES_TIPO_RECOGIDAS = new HashSet<CIUDADES_TIPO_RECOGIDAS>();
            this.CONFIGURACION_EXCEL = new HashSet<CONFIGURACION_EXCEL>();
            this.FACTURACION = new HashSet<FACTURACION>();
            this.PUNTOS_RUTA = new HashSet<PUNTOS_RUTA>();
            this.RUTAS = new HashSet<RUTAS>();
            this.TARIFAS = new HashSet<TARIFAS>();
            this.USUARIO_CIUDADES = new HashSet<USUARIO_CIUDADES>();
        }
    
        public string ID { get; set; }
        public string IDPAIS { get; set; }
        public string NOMBRE_CIUDAD { get; set; }
    
        public virtual PAISES PAISES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CIUDADES_TIPO_RECOGIDAS> CIUDADES_TIPO_RECOGIDAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFIGURACION_EXCEL> CONFIGURACION_EXCEL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURACION> FACTURACION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PUNTOS_RUTA> PUNTOS_RUTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RUTAS> RUTAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TARIFAS> TARIFAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO_CIUDADES> USUARIO_CIUDADES { get; set; }
    }
}