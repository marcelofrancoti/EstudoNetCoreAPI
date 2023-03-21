using Imobi.Business.Interfaces;
using Imobi.Data.Acessos;
using Imobi.Data.DataClass;
using Imobi.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace Imobi.Business.GerenciamentoImovel
{

    public class FormaDePagamentoBusiness : IFormaDePagamentoBusiness
    {
        public  List<FormaDePagamento> selectTodasFormaDePagamento()
        {
            List<FormaDePagamento> formasDePagamento = new List<FormaDePagamento>();

            AcessoImobi acessoImobi = new AcessoImobi();
            var dt = FormaDePagamentoData.selectTodasFormaDePagamento(acessoImobi.AbrirConexao());

            foreach (DataRow item in dt.Rows)
            {
                FormaDePagamento formaDePagamento = new FormaDePagamento();
                formaDePagamento.DESCRICAO = item["DESCRICAO"].ToString();
                formaDePagamento.FORMA_DE_PAGAMENTO_ID = int.Parse(item["FORMA_DE_PAGAMENTO_ID"].ToString());

                formasDePagamento.Add(formaDePagamento);
            }

            return formasDePagamento;
        }

        public  string selectFormaDePagamento_Descricao(string descricao)
        {
            string retorno = String.Empty;


            AcessoImobi acessoImobi = new AcessoImobi();
            var dt = FormaDePagamentoData.selectFormaDePagamento_Descricao(descricao, acessoImobi.AbrirConexao());

            foreach (DataRow item in dt.Rows)
            {
                retorno = string.Concat("Forma_De_Pagamento Descricao: ", item["DESCRICAO"].ToString(), ", Forma_De_Pagamento Id ", int.Parse(item["FORMA_DE_PAGAMENTO_ID"].ToString()));
            }

            return retorno;
        }


        public  bool InserirFormaDePagamento(string descricao)
        {
            AcessoImobi acessoImobi = new AcessoImobi();

            if (FormaDePagamentoData.InserirFormaDePagamento(descricao, acessoImobi.AbrirConexao()))
                return true;

            return false;
        }

        //private static bool DeletarTodosBairros()
        //{
        //}


        //private static bool DeletarBairro_ID(int id)
        //{
        //}

        //private static bool AtualizarBairro(int id, string nome, SqlConnection sqlConnection)
        //{
        //}


    }
}