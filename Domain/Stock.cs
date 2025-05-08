using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

        public class Stock
        {
            public Guid Id_stock { get; set; }  // Ahora usa Guid en vez de int, y tuvimos que cambiar en las firmas, e instancias, y cuando estaba en 0 lo reemplazamos por Guid.empty
            public int Nro_repuesto { get; set; }
            public string Nombre_repuesto { get; set; }
            public string Descripcion { get; set; }
            public int Cantidad { get; set; }

        //tranforma los objetos(los parametros) en otros objetos, para manejarlos
        //esto lo usabamos antes de aplicar adapter
        /*public Stock(Guid pId_stock, int pNro_repuesto, string pNombre_repuesto, string pDescripcion, int pCantidad)
            {
                Id_stock = pId_stock;
                Nro_repuesto = pNro_repuesto;
                Nombre_repuesto = pNombre_repuesto;
                Descripcion = pDescripcion;
                Cantidad = pCantidad;
            }*/
        }
}
