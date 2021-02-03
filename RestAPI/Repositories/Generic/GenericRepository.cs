using Microsoft.EntityFrameworkCore;
using RestAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;


namespace  RestAPI.Repositories.Generic
{
    /*CRUD GENÉRICO, OU SEJA ACEITA QUALQUER CLASSE*/
    
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly OracleContext _context;

        // DATASET - SETAR ORACLE
        private DbSet<T> dataset;

        public GenericRepository(OracleContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }


        public T salvar(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void remover(T item)
        {
            //var result = dataset.SingleOrDefault(i => i.Id.Equals(id));

            try
            {
                if (item != null)
                {
                    dataset.Remove(item);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public T buscarId(long? id)
        {
           return dataset.Find(id);
        }

        public bool existir(long? id)
        {

            return false;
        }

        public List<T> buscarTodos()
        {
            return dataset.ToList();
        }

        public T buscarPorId(long id)
        {
            return dataset.Find(id);
        }

        public List<T> buscarPorPaginacao(string query)
        {
            return null; //dataset.FromSql<T>(query).ToList();
        }
        
        public int contarLinhas(string query)
        {
			
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }

            return Int32.Parse(result);
        }

        public T alterar(T item)
        {
            if (item != null)
            {
                try
                {
                    //_context.Entry(result).CurrentValues.SetValues(item);
                    dataset.Update(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }
    }
}
