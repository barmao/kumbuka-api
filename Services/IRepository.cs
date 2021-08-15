using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kumbuka_api.Services
{
    public interface IRepository<T> where T : class
    {
        int SaveChangesAndGetInsertedId(T entity, string sql);
        void SaveChanges(T entity);
        void SaveChanges(T entity, string sql);
        void Delete(T entity);
        void Update(T entity);
        void Update(T entity, string col);
        IEnumerable<T> Query(string where = null);
        T GetFirstOrDefault(string filter);
    }
}
