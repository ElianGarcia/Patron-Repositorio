using PatronRepositorio.DAL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PatronRepositorio.BLL
{
    public class GenericaBLL<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto db;

        public GenericaBLL()
        {
            db = new Contexto();
        }

        public T Buscar(int id)
        {
            T entity;

            try
            {
                entity = db.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public bool Eliminar(int id)
        {
            bool realizado = false;

            try
            {
                T entity = db.Set<T>().Find(id);
                db.Set<T>().Remove(entity);

                realizado = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return realizado;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Listado = new List<T>();

            try
            {
                Listado = db.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return Listado;

        }

        public bool Guardar(T entity)
        {
            bool realizado = false;

            try
            {
                if (db.Set<T>().Add(entity) != null)
                    realizado = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return realizado;
        }

        public bool Modificar(T entity)
        {
            bool realizado = false;

            try
            {
                db.Entry(entity).State = EntityState.Modified;
                realizado = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return realizado;
        }
    }
}
