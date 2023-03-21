using Imobi.Business.Interfaces;
using Imobi.Data.DataClassDapper;
using Imobi.Entity;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Imobi.Business.GerenciamentoUsuario
{

    public class BairroBusiness : IBairroBusiness
    {
        public void Excluir(Bairro a)
        {
            BairroDataDapper BairroDataDapper = new BairroDataDapper();
            BairroDataDapper.Excluir(a);
        }

        public void Atualizar(Bairro a)
        {
            BairroDataDapper BairroDataDapper = new BairroDataDapper();
            BairroDataDapper.Atualizar(a);
        }

        public void Inserir(Bairro a)
        {
            BairroDataDapper BairroDataDapper = new BairroDataDapper();
            BairroDataDapper.Inserir(a);
        }

        public IEnumerable<Bairro> BuscarTodos()
        {
            BairroDataDapper BairroDataDapper = new BairroDataDapper();
            return BairroDataDapper.BuscarTodos();
        }

        public Bairro BuscarPorId(int Id)
        {
            BairroDataDapper BairroDataDapper = new BairroDataDapper();
            return BairroDataDapper.BuscarTodos().Where<Bairro>(f => f.BAIRRO_ID == Id).FirstOrDefault();
        }
    }
}