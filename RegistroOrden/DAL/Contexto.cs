using Microsoft.EntityFrameworkCore;
using RegistroOrden.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroOrden.DAL
{
    public class Contexto : DbContext
    {   
        public DbSet<Clientes> Cliente { get; set; } 
        public DbSet<Ordenes> Ordene { get; set; }
        public DbSet<Productos> Producto { get; set; }
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Producto.db ");
        }
    }
}
