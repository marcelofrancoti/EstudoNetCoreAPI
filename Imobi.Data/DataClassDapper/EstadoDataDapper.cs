using Dapper;
using Imobi.Data.Acessos;
using Imobi.Data.Acessos.DataInterfaces;
using Imobi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Data.DataClassDapper
{
    public class EstadoDataDapper : IDataQuery<Estado>
    {
        private AcessoDataDapper _acessoDataDapper = new AcessoDataDapper();
        public Estado BuscarPorId(int Id)
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Estado>(@"
                 SELECT[ESTADO_ID]
                    ,[UF]
                    ,[DESCRICAO]
                FROM[dbo].[TB_ESTADO]
                WHERE ESTADO_ID = @ESTADO_ID",Id).FirstOrDefault();
        }

        public IEnumerable<Estado> BuscarTodos()
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Estado>(@"
                 SELECT[ESTADO_ID]
                    ,[UF]
                    ,[DESCRICAO]
                FROM[dbo].[TB_ESTADO]");
        }
    }
}
