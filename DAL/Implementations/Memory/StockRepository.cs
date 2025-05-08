using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations.Memory
{
    internal class StockRepository : IStockRepository
    {

        /*private readonly string connectionString;

        public StockRepository(string connectionString)
        {
            this.connectionString = connectionString;
            //implementamos un constructor para las conexiones a bases de datos
        }*/
        public void Add(Stock entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid idStock)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stock> GetAll()
        {
            throw new NotImplementedException();
        }

        public Stock GetbyId(Guid idStock)
        {
            throw new NotImplementedException();
        }

        public void Update(Stock entity)
        {
            throw new NotImplementedException();
        }
    }
}
