//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace crudLimpio2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public int Producto_id { get; set; }
        public string Prod_nombre { get; set; }
        public string Prod_descripción { get; set; }
        public int Prod_cantidad { get; set; }
        public System.DateTime Prod_fechaRegistro { get; set; }
        public Nullable<System.DateTime> Prod_fechaActualizacion { get; set; }
        public int Prod_estatus { get; set; }
    }
}
