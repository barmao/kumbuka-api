using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kumbuka_api.Repository
{
    public class GenericRepository<T> : KumbukaRepository<T> where T : class
    {
        public IEnumerable<T> GetAll()
        {
            return Query();
        }

        public IEnumerable<T> GetSelected()
        {
            return ExecQuery();
        }
    }
}
