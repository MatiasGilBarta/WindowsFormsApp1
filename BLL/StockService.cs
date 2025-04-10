using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL.Implementations.SQLServer;
using DAL.Factory;
using System.Configuration;
using DAL.Interfaces;


namespace BLL
{
    public class StockService
    {
        private readonly IStockRepository stockRepository;

        //private string connectionString;

        public StockService()
        {
            stockRepository = DAL.Factory.Repository.GetStockInstance(); // ✅ Se obtiene desde la Factory
        }

        public void AgregarStock(Stock stock)
        {
            stockRepository.Add(stock);
        }

        public void ModificarStock(Stock stock)
        {
            stockRepository.Update(stock);
        }

        public void EliminarStock(int idStock)
        {
            stockRepository.Delete(idStock);
        }

        public List<Stock> ObtenerStock()
        {
            return stockRepository.GetAll().ToList(); // ✅ Convierte a List<Stock> de forma segura
        }
    }
}

