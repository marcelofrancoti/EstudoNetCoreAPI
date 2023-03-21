using Imobi.Entity;
using System.Collections.Generic;

namespace Imobi.Business.Interfaces
{
    public interface IFormaDePagamentoBusiness
    {
        List<FormaDePagamento> selectTodasFormaDePagamento();
        string selectFormaDePagamento_Descricao(string descricao);
        bool InserirFormaDePagamento(string descricao);

    }
}
