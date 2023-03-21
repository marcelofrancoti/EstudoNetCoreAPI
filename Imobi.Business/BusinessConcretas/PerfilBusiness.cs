using Imobi.Business.Interfaces;
using Imobi.Data.Acessos;
using Imobi.Data.DataClass;
using Imobi.Entity;
using System.Collections.Generic;
using System.Data;

namespace Imobi.Business.BusinessConcretas
{
    public class PerfilBusiness : IPerfilBusiness
    {
        public  List<Perfil> SelectTodosPerfil()
        {
            Perfil perfil = new Perfil();
            List<Perfil> perfils = new List<Perfil>();


            AcessoImobi acessoImobi = new AcessoImobi();
            var dt = PerfilData.SelectTodosPerfil(acessoImobi.AbrirConexao());

            foreach (DataRow item in dt.Rows)
            {
                perfil.DESCRICAO = item["DESCRICAO"].ToString();
                perfil.PERFIL_ID = int.Parse(item["PERFIL_ID"].ToString());

                perfils.Add(perfil);
            }

            return perfils;
        }
        public  List<Perfil> SelectPerfil_Descricao(string descricao)
        {
            Perfil perfil = new Perfil();
            List<Perfil> perfils = new List<Perfil>();


            AcessoImobi acessoImobi = new AcessoImobi();
            var dt = PerfilData.SelectPerfil_Descricao(descricao,acessoImobi.AbrirConexao());

            foreach (DataRow item in dt.Rows)
            {
                perfil.DESCRICAO = item["DESCRICAO"].ToString();
                perfil.PERFIL_ID = int.Parse(item["PERFIL_ID"].ToString());

                perfils.Add(perfil);
            }

            return perfils;
        }
        public  bool InserirPerfil(string descricao)
        {
            AcessoImobi acessoImobi = new AcessoImobi();

            if (PerfilData.InserirPerfil(descricao, acessoImobi.AbrirConexao()))
                return true;

            return false;
        }

    }
}
