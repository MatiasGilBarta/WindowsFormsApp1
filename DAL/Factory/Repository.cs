using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Implementations.SQLServer;
using DAL.Interfaces;

namespace DAL.Factory //el resto de la clase es factory
{
    public sealed class Repository //singleton me queda hacerlo trhead safe
    {
        private static readonly Repository _instance = new Repository();

        public static Repository Current
        {
            get
            {
                return _instance;
            }
        }
        //singleton, es para para mostrar la unica instancia

        //public static Repository Instance => _instance; 
        //singleton, tambien muestra la unica instacia pero la diferencia es solo de sintaxis


        //capaz ahora que tengo el helper vamos a tener que cambiar esto
        private readonly string backendType = ConfigurationManager.AppSettings["ProyectoGestor"];
        //private readonly string connectionString = ConfigurationManager.ConnectionStrings["ProyectoGestor"].ConnectionString;
        //hasta aca
        private Repository() //singleton
        {
            // Inicialización
        }

        public IStockRepository GetStockInstance()
        {
            if (backendType == "memory")
            {
                return new DAL.Implementations.Memory.StockRepository();
            }
            else if (backendType == "sqlserver")
            {
                return new DAL.Implementations.SQLServer.StockRepository();
            }

            throw new Exception("Backend no soportado.");
        }

        // Podés agregar más GetXRepository() acá si querés extenderlo
    }
}
