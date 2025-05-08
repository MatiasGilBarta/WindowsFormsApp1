using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    //el adaptador lo usamos cuando queremos 2 interfaces distintas puedan trabajar juntas
    //en nuestro caso es pq tenemos 2 objetos, que son Stock y object[]
    //cabe recalcar que no es una version purista, ya que no cumple 100% con el patron, es una interfaz simple
    internal interface IAdapter<T> where T : class
    {
        T Get(object[] values);
    }
}
