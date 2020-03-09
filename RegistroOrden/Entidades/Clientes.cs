using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroOrden.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public int Cedula { get; set; }

        [ForeignKey("ClienteId")]
        public virtual List<Ordenes> OrdenesList { get; set; } = new List<Ordenes>();
        [ForeignKey("ClienteId")]
        public virtual List<OrdenDetalles> OrdenesDetalle { get; set; } = new List<OrdenDetalles>();
        public Clientes() { }

        public Clientes(int clienteId, string nombres, string direccion, int cedula, List<Ordenes> ordenesList, List<OrdenDetalles> ordenesDetalle)
        {
            ClienteId = clienteId;
            Nombres = nombres;
            Direccion = direccion;
            Cedula = cedula;
            OrdenesList = ordenesList;
            OrdenesDetalle = ordenesDetalle;
        }
    }
    
}
