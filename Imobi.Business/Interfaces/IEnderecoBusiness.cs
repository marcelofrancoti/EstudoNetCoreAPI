using Imobi.Data.Acessos;
using Imobi.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Business.Interfaces
{
    public interface IEnderecoBusiness
    {
        List<Endereco> SelectTodosEnderecos();
        List<Endereco> SelectEndereco_Cep(int cep);
        bool InserirEndereco(int cep, string nomeRua, int numero);
    }
}
