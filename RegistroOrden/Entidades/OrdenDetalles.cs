using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroOrden.Entidades
{
    public class OrdenDetalles
    {
        [Key]
        public int OrdenDetalleId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
   
        public OrdenDetalles()
        {
            ////OrdenDetalleId = 0;
            ////OrdenId = 0;
            ////ProductoId = 0;
            ////ClienteId = 0;
            ////Descripcion = string.Empty;
            ////Cantidad = 0;
            ////Precio = 0;
            ////Total = 0;
        }

        public OrdenDetalles( int ordenId, int productoId, int clienteId, string descripcion, int cantidad, decimal precio, decimal total)
        {
            OrdenDetalleId = 0;
            OrdenId = ordenId;
            ProductoId = productoId;
            ClienteId = clienteId;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            Total = total;
        }
    }
}
