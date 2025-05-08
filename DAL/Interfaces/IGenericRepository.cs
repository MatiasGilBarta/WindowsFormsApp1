using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(Guid id);

        IEnumerable<T> GetAll();

        T GetbyId(Guid id);

    }
}
