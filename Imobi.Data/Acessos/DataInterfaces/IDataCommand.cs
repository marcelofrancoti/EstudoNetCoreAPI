using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Data.Acessos.DataInterfaces
{
    public interface IDataCommand<T>
    {

        void Excluir(T a);
        void Atualizar(T a);
        void Inserir(T a);
    }
}
