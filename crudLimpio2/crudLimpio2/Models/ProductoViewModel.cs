using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace crudLimpio2.Models
{
    public class ProductoViewModel
    {
        [Required]
        [Display(Name = "Clave de Producto")]
        public int Producto_id { get; set; }

        [Required]
        [Display(Name = "Nombre de Producto")]
        public string Prod_nombre { get; set; }

        [Required]
        [Display(Name = "Descripción de Producto")]
        public string Prod_descripción { get; set; }

        [Required]
        [Display(Name = "Cantidad de Producto")]
        [Range(0, int.MaxValue, ErrorMessage = "Ingresa un número entero")]
        public int Prod_cantidad { get; set; }

        public System.DateTime Prod_fechaRegistro { get; set; }
        public Nullable<System.DateTime> Prod_fechaActualizacion { get; set; }
        public int Prod_estatus { get; set; }
    }
}