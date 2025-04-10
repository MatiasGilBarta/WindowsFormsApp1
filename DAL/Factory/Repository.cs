using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Implementations.SQLServer;
using DAL.Interfaces;

namespace DAL.Factory
{
    public static class Repository
    {

        static string backendType = ConfigurationManager.AppSettings["ProyectoGestor"];

        static string connectionString;

        public static IStockRepository GetStockInstance()
        {

            if (backendType == "memory")
            {
                //connectionString = ConfigurationManager.ConnectionStrings.["sqlserver"].connectionstring
                // este tambien es de ejemplo, pq en memory no hace falta connection string
                return new DAL.Implementations.Memory.StockRepository(/*connectionString*/);
            }
            else if (backendType == "sqlserver")
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ProyectoGestor"].ConnectionString;
                return new DAL.Implementations.SQLServer.StockRepository(connectionString);
            }
            /*else if (backendType == "mysql")
            {
                connectionString = ConfigurationManager.ConnectionStrings.["mysql"].connectionstring
             este es a modo de ejemplo, meto el connection string correspondiente de la tecnologia
                return new DAL.Implementations.SQLServer.StockRepository();
            }*/
            throw new Exception("BackendType no soportado en Repository");//este hay que comentarlo despues para resolver problemas que tapa
        }
    }
}
