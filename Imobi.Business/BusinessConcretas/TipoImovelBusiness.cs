using Imobi.Data.Acessos;
using System.Collections.Generic;
using System.Data;
using Imobi.Business.Interfaces;
using Imobi.Data.DataClass;
using Imobi.Entity;

namespace Imobi.Business.BusinessConcretas
{
    public class TipoImovelBusiness : ITipoImovelBusiness
    {
        public   List<TipoImovel> SelectTodosTipoImovel()
        {
            TipoImovel tipoImovel = new TipoImovel();
            List<TipoImovel> tiposImovel = new List<TipoImovel>();


            AcessoImobi acessoImobi = new AcessoImobi();
            var dt = TipoImovelData.SelectTodosTipoImovel(acessoImobi.AbrirConexao());

            foreach (DataRow item in dt.Rows)
            {
                tipoImovel.TIPO_IMOVEL_ID = int.Parse(item["TIPO_IMOVEL_ID"].ToString());
                tipoImovel.DESCRICAO = item["DESCRICAO"].ToString();

                tiposImovel.Add(tipoImovel);
            }

            return tiposImovel;
        }
        public List<TipoImovel> SelectTipoImovel_Descricao(string descricao)
        {
            TipoImovel tipoImovel = new TipoImovel();
            List<TipoImovel> tiposImovel = new List<TipoImovel>();

            AcessoImobi acessoImobi = new AcessoImobi();
            var dt = TipoImovelData.SelectTipoImovel_Descricao(descricao, acessoImobi.AbrirConexao());

            foreach (DataRow item in dt.Rows)
            {
                tipoImovel.TIPO_IMOVEL_ID = int.Parse(item["TIPO_IMOVEL_ID"].ToString());
                tipoImovel.DESCRICAO = item["DESCRICAO"].ToString();

                tiposImovel.Add(tipoImovel);
            }

            return tiposImovel;
        }
        public   bool InserirTipoImovel(string descricao)
        {
            AcessoImobi acessoImobi = new AcessoImobi();

            if (TipoImovelData.InserirTipoImovel(descricao, acessoImobi.AbrirConexao()))
                return true;

            return false;
        }
    }
}
