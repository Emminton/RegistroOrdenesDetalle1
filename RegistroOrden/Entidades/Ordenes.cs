using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroOrden.Entidades
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadOrden { get; set; }
        //public decimal Precio { get; set; }
        //public decimal MontoTotal { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenDetalles> OrdenesDetalle { get; set; } = new List<OrdenDetalles>();
        public Ordenes()
        { }

        public Ordenes(int ordenId, int clienteId, DateTime fecha, int cantidadOrden, List<OrdenDetalles> ordenesDetalle)
        {
            OrdenId = ordenId;
            ClienteId = clienteId;
            Fecha = fecha;
            CantidadOrden = cantidadOrden;
            //Precio = precio;decimal precio, decimal montoTotal,
            //MontoTotal = montoTotal;
            OrdenesDetalle = ordenesDetalle;

        }
    }
}
