using System.Collections.Generic;
using System.Data;
using Imobi.Business.Interfaces;
using Imobi.Data.DataClassDapper;
using System.Linq;
using Imobi.Entity;

namespace Imobi.Business.BusinessConcretas
{
    public class EstadoBusiness : IEstadoBusiness
    {
        public  string SelectEstado_Uf(string uf)
        {
            EstadoDataDapper estadoDataDapper = new EstadoDataDapper();
            return estadoDataDapper.BuscarTodos().Where(_ => _.UF == uf).FirstOrDefault().DESCRICAO;
        }

        public IEnumerable<Estado> BuscarTodos()
        {
            EstadoDataDapper estadoDataDapper = new EstadoDataDapper();
            return estadoDataDapper.BuscarTodos();
        }

        public Estado BuscarPorId(int Id)
        {
            EstadoDataDapper estadoDataDapper = new EstadoDataDapper();
            return estadoDataDapper.BuscarPorId(Id);
        }
    }
}

