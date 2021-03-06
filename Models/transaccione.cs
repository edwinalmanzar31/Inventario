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

    public partial class transaccione
    {
        [Display(Name = "Transacción")]
        public int id { get; set; }

        [Display(Name = "Tipo de transacción")]
        public string tipoTransaccion { get; set; }

        [Display(Name = "Articulo")]
        public Nullable<int> idArticulo { get; set; }

        [Display(Name = "Almacén")]
        public Nullable<int> idAlmacen { get; set; }

        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> fecha { get; set; }

        [Display(Name = "Cantidad")]
        public Nullable<int> cantidad { get; set; }

        [Display(Name = "Monto")]
        public Nullable<decimal> monto { get; set; }
    
        public virtual almacen almacen { get; set; }
        public virtual articulo articulo { get; set; }
    }
}
