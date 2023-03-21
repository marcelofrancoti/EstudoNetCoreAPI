using Dapper;
using Imobi.Data.Acessos;
using Imobi.Data.Acessos.DataInterfaces;
using Imobi.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Data.DataClassDapper
{
    public class CidadeDataDapper : IDataAdmin<Cidade>
    {
        AcessoDataDapper _acessoDataDapper = new AcessoDataDapper();
        public void Atualizar(Cidade a)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
                                                        UPDATE [dbo].[TB_CIDADE]
                                                           SET [NOME_CIDADE] = @NOME_CIDADE]
                                                           SET [ESTADO_ID] =  @ESTADO_ID
                                                         WHERE CIDADE_ID = @CIDADE_ID
                                                    ", a);
        }

        public Cidade BuscarPorId(int Id)
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Cidade>(@"
                                                SELECT[CIDADE_ID]
                                                      ,[NOME_CIDADE]
                                                      ,[ESTADO_ID]
                                                  FROM[dbo].[TB_CIDADE]
                                            where CIDADE_ID = @CIDADE_ID
                                                    ", Id).FirstOrDefault();
        }



        public IEnumerable<Cidade> BuscarTodos()
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Cidade>(@"
                                                SELECT[CIDADE_ID]
                                                      ,[NOME_CIDADE]
                                                      ,[ESTADO_ID]
                                                  FROM[dbo].[TB_CIDADE]");
        }

        public void Excluir(Cidade a)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@" 
                                                                DELETE FROM [dbo].[TB_CIDADE] WHERE CIDADE_ID = @CIDADE_ID ",a.CIDADE_ID);
        }

        public void Inserir(Cidade a)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
                                                        INSERT INTO [dbo].[TB_CIDADE]
                                                        ([NOME_CIDADE], ESTADO_ID)
                                                        VALUES
                                                        (@NOME_CIDADE, @ESTADO_ID)
                                                    ", new { a.NOME_CIDADE, a.ESTADO_ID});
        }
    }
}
