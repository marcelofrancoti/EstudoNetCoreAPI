using Imobi.Data.Acessos;
using System;
using System.Collections.Generic;
using System.Data;
using Imobi.Business.Interfaces;
using Imobi.Data.DataClass;
using Imobi.Entity;
using Imobi.Data.DataClassDapper;

namespace Imobi.Business.BusinessConcretas
{
    public class CidadeBusiness : ICidadeBusiness
    {
        

        public void Excluir(Cidade a)
        {
            CidadeDataDapper cidadeDapper = new CidadeDataDapper();
            cidadeDapper.Excluir(a);
        }

        public void Atualizar(Cidade a)
        {
            CidadeDataDapper cidadeDapper = new CidadeDataDapper();
            cidadeDapper.Atualizar(a);
        }

        public void Inserir(Cidade a)
        {
            CidadeDataDapper cidadeDapper = new CidadeDataDapper();
            cidadeDapper.Inserir(a);
        }

        public IEnumerable<Cidade> BuscarTodos()
        {
            CidadeDataDapper cidadeDapper = new CidadeDataDapper();
            return cidadeDapper.BuscarTodos();
        }

        public Cidade BuscarPorId(int Id)
        {
            CidadeDataDapper cidadeDapper = new CidadeDataDapper();
            return cidadeDapper.BuscarPorId(Id);
        }
    }
}

