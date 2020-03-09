using Microsoft.EntityFrameworkCore;
using RegistroOrden.DAL;
using RegistroOrden.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroOrden.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Ordene.Add(ordenes) != null)
                    paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Ordenes ordenes)
        {           
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM OrdenDetalles Where OrdenId = {ordenes.OrdenId}");

                foreach (var item in ordenes.OrdenesDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(ordenes).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Ordene.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Ordenes ordenes = new Ordenes();
            Contexto db = new Contexto();

            try
            {
                ordenes = db.Ordene.Include(o => o.OrdenesDetalle).Where(o => o.OrdenId == id).SingleOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return ordenes;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> ordenes)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Ordene.Where(ordenes).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
