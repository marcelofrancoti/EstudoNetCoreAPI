using Imobi.Entity;
using System.Collections.Generic;

namespace Imobi.Business.Interfaces
{
    public interface IPerfilBusiness
    {
        List<Perfil> SelectTodosPerfil();
        List<Perfil> SelectPerfil_Descricao(string descricao);
        bool InserirPerfil(string descricao);
    }
}
