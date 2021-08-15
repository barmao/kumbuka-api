using Dapper;
using kumbuka_api.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace kumbuka_api.Repository
{
    public abstract class KumbukaRepository<T> : IRepository<T> where T : class
    {
        protected string connectionString = Program.DbConnectionString;
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetFirstOrDefault(string filter)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Query(string where = null)
        {
            var query = $"SELECT * FROM {typeof(T).Name}";

            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<T>(query);
            }
        }

        public virtual IEnumerable<T> ExecQuery(string where = null)
        {
            var columns = GetSelectedColumns();
            var stringOfColumns = string.Join(",", columns);
            var query = $"SELECT {stringOfColumns} FROM {typeof(T).Name}";

            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<T>(query);
            }

        }

        private IEnumerable<string> GetSelectedColumns()
        {
            return typeof(T)
                    .GetProperties()
                    .Select(e => e.Name);
        }
        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

        public void SaveChanges(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges(T entity, string sql)
        {
            throw new NotImplementedException();
        }

        public int SaveChangesAndGetInsertedId(T entity, string sql)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity, string col)
        {
            throw new NotImplementedException();
        }
    }
}
