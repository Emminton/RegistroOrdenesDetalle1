using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroOrden.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }

        [ForeignKey("ProductoId")]
        public virtual List<OrdenDetalles> OrdenesDetalle { get; set; } = new List<OrdenDetalles>();
        public Productos() { }

        public Productos(int productoId, string nombreProducto, decimal precioProducto, List<OrdenDetalles> ordenesDetalle)
        {
            ProductoId = productoId;
            NombreProducto = nombreProducto;
            PrecioProducto = precioProducto;
            OrdenesDetalle = ordenesDetalle;
        }
    }
}
