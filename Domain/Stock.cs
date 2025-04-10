using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

        public class Stock
        {
            public int Id_stock { get; set; }  // Ahora tiene el ID autonumerado
            public int Nro_repuesto { get; set; }
            public string Nombre_repuesto { get; set; }
            public string Descripcion { get; set; }
            public int Cantidad { get; set; }

        public Stock(int pId_stock, int pNro_repuesto, string pNombre_repuesto, string pDescripcion, int pCantidad)
            {
                Id_stock = pId_stock;
                Nro_repuesto = pNro_repuesto;
                Nombre_repuesto = pNombre_repuesto;
                Descripcion = pDescripcion;
                Cantidad = pCantidad;
            }
        }
}
