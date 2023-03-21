using Imobi.Business.Interfaces;
using Imobi.Data.DataClassDapper;
using Imobi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Business.BusinessConcretas
{
    public class TelefoneBusiness : ITelefoneBusiness
    {
        TelefoneDataDapper _telefoneDataDapper = new TelefoneDataDapper();
        public void Atualizar(Telefone a)
        {
            _telefoneDataDapper.Atualizar(a);
        }

        public Telefone BuscarPorId(int Id)
        {
            return _telefoneDataDapper.BuscarPorId(Id);
        }

        public IEnumerable<Telefone> BuscarTodos()
        {
            return _telefoneDataDapper.BuscarTodos();
        }

        public void Excluir(Telefone a)
        {
            _telefoneDataDapper.Excluir(a);
        }

        public void Inserir(Telefone a)
        {
            _telefoneDataDapper.Inserir(a);
        }
    }
}
