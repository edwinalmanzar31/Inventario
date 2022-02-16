//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public articulo()
        {
            this.existencia_almacen = new HashSet<existencia_almacen>();
            this.transacciones = new HashSet<transaccione>();
        }
    
        public int id { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Existencia")]
        public string existencia { get; set; }

        [Display(Name = "Tipo inventario")]
        public Nullable<int> idTipoInventario { get; set; }

        [Display(Name = "Costo unitario")]
        public Nullable<decimal> costoUnitario { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Display(Name = "Tipo Inventario")]
        public virtual tiposInventario tiposInventario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<existencia_almacen> existencia_almacen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transaccione> transacciones { get; set; }
    }
}
