using Imobi.Entity;
using System.Collections.Generic;

namespace Imobi.Business.Interfaces
{
    public interface ITipoImovelBusiness
    {
        List<TipoImovel> SelectTodosTipoImovel();
        List<TipoImovel> SelectTipoImovel_Descricao(string descricao);
        bool InserirTipoImovel(string descricao);

    }
}
