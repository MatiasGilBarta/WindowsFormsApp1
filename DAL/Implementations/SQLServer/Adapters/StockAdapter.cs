using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations.SQLServer.Adapters
{
    public sealed class StockAdapter : IAdapter<Stock>
    {
        //este adapter que estamos haciendo va usar singleton pq no guarda estados
        //los servicios en general no guardan estado, no tienen estado, ya que trabajan por demanda
        //vos haces x y me devolves x

        #region Singleton
        private readonly static StockAdapter Instance = new StockAdapter();

        public static StockAdapter Current
        {  
            get 
            { 
                return Instance; 
            } 
        }
        private StockAdapter() 
        { 
            //implementa aqui la inicializacion del singleton
        }
        #endregion
        //fin del singleton dentro del adapter
        public Stock Get(object[] values)
        {
            try
            {
                return new Stock()
                {
                    Id_stock = Guid.Parse(values[(int)StockFields.Id_stock]?.ToString()),
                    Nro_repuesto = int.Parse(values[(int)StockFields.Nro_repuesto]?.ToString()),
                    Nombre_repuesto = values[(int)StockFields.Nombre_repuesto]?.ToString(),
                    Descripcion = values[(int)StockFields.Descripcion]?.ToString(),
                    Cantidad = int.Parse(values[(int)StockFields.Cantidad]?.ToString())
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear Stock: " + ex.Message);
            }
        }

        internal enum StockFields 
        {
            Id_stock = 0,
            Nro_repuesto = 1,
            Nombre_repuesto = 2,
            Descripcion = 3,
            Cantidad = 4
        }
    }

}
