using BLL.Interfaces;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Implementations.SQLServer;
using DAL.Factory;

namespace BLL.Servicies
{
    public class StockService : IStockService
    {
        //--------------------------------------
        private readonly IStockRepository stockRepository;

        //private string connectionString;

        public StockService()
        {
            stockRepository = Repository.Current.GetStockInstance(); //instacia desde la factory pero mezclado con singleton
            //stockRepository = DAL.Factory.Repository.GetStockInstance(); // ✅ Se obtiene desde la Factory
        }
        //--------------------------------------
        public void Add(Stock stock)
        {
            stockRepository.Add(stock);
        }

        public void Update(Stock stock)
        {
            stockRepository.Update(stock);
        }

        public void Delete(Guid idStock)
        {
            stockRepository.Delete(idStock);
        }

        public IEnumerable<Stock> GetAll()
        {
            return stockRepository.GetAll();
        } 

        public Stock GetbyId(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
