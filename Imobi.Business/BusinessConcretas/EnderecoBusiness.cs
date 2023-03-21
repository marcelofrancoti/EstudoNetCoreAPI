using Imobi.Data.Acessos;
using System.Collections.Generic;
using System.Data;
using Imobi.Business.Interfaces;
using Imobi.Data.DataClass;
using Imobi.Entity;

namespace Imobi.Business.BusinessConcretas
{
    public class EnderecoBusiness : IEnderecoBusiness
    {
        public List<Endereco> SelectTodosEnderecos()
        {
            Endereco endereco = new Endereco();
            List<Endereco> enderecos = new List<Endereco>();


            AcessoImobi acessoImobi = new AcessoImobi();
            var dt = EnderecoData.SelectTodosEnderecos(acessoImobi.AbrirConexao());

            foreach (DataRow item in dt.Rows)
            {
                endereco.ENDERECO_ID = int.Parse(item["ENDERECO_ID"].ToString());
                endereco.CIDADE_ID = int.Parse(item["CIDADE_ID"].ToString());
                endereco.BAIRRO_ID = int.Parse(item["BAIRRO_ID"].ToString());
                endereco.ENDERECO_CEP = int.Parse(item["ENDERECO_CEP"].ToString());
                endereco.NOME_RUA = item["NOME_RUA"].ToString();
                endereco.ENDERECO_NUMERO = int.Parse(item["ENDERECO_NUMERO"].ToString());

                enderecos.Add(endereco);
            }

            return enderecos;
        }

        public List<Endereco> SelectEndereco_Cep(int cep)
        {
            Endereco endereco = new Endereco();
            List<Endereco> enderecos = new List<Endereco>();

            AcessoImobi acessoImobi = new AcessoImobi();
            var dt = EnderecoData.SelectEndereco_Cep(cep, acessoImobi.AbrirConexao());

            foreach (DataRow item in dt.Rows)
            {
                endereco.ENDERECO_ID = int.Parse(item["ENDERECO_ID"].ToString());
                endereco.CIDADE_ID = int.Parse(item["CIDADE_ID"].ToString());
                endereco.BAIRRO_ID = int.Parse(item["BAIRRO_ID"].ToString());
                endereco.ENDERECO_CEP = int.Parse(item["ENDERECO_CEP"].ToString());
                endereco.NOME_RUA = item["NOME_RUA"].ToString();
                endereco.ENDERECO_NUMERO = int.Parse(item["ENDERECO_NUMERO"].ToString());

                enderecos.Add(endereco);
            }

            return enderecos;
        }


        public bool InserirEndereco(int cep, string nomeRua, int numero)
        {
            AcessoImobi acessoImobi = new AcessoImobi();

            if (EnderecoData.InserirEndereco(cep, nomeRua, numero, acessoImobi.AbrirConexao()))
                return true;

            return false;
        }





    }
}

