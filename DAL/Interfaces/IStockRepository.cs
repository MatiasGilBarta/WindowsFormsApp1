using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStockRepository : IGenericRepository<Stock>
    {

        //aca pueden ir firmas especificas de la entidad si hacen falta
        //puedo poner aca la calse para meter la connectionstring(backendtype)?
    }
}
