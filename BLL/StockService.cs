using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL;
using System.Configuration;

namespace BLL
{
    public class StockService
    {
        
        private SQL.ListarStock _stockDAL;

        public StockService()
        {
            _stockDAL = new SQL.ListarStock();
        }

        // Método para agregar un stock
        public void AgregarStock(Stock stock)
        {
            _stockDAL.AgregarStock(stock);
        }

        // Método para retornar la lista de stocks
        public List<Stock> ObtenerStock()
        {
            return _stockDAL.RetornarStock();
        }

        // Método para eliminar un stock
        public void EliminarStock(int idStock)
        {
            _stockDAL.BorrarStock(idStock);
        }

        // Método para modificar un stock
        public void ModificarStock(Stock stock)
        {
            _stockDAL.ModificarStock(stock);
        }
    }
}

