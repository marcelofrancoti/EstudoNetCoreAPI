using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Data.Acessos.DataInterfaces
{
    public interface IDataQuery<T>
    {
        IEnumerable<T> BuscarTodos();
        T BuscarPorId(int Id);
    }
}
