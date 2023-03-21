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
    public class TelefoneDataDapper : IDataAdmin<Telefone>
    {
        AcessoDataDapper _acessoDataDapper = new AcessoDataDapper();
        public void Atualizar(Telefone a)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute("UPDATE TB_TELEFONE SET DDD = @DDD, NUMERO = @NUMERO, TIPO_TELEFONE = @TIPO_TELEFONE",a);
        }

        public Telefone BuscarPorId(int Id)
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Telefone>(@"
                        SELECT [TELEFONE_ID]
                                                                          ,[TIPO_TELEFONE]
                                                                          ,[DDD]
                                                                          ,[NUMERO]
                                                                      FROM [dbo].[TB_TELEFONE]
                                                                      WHERE TELEFONE_ID = @Id", new { Id }).FirstOrDefault();}

        public IEnumerable<Telefone> BuscarTodos()
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Telefone>(@"
                        SELECT [TELEFONE_ID]
                                                                          ,[TIPO_TELEFONE]
                                                                          ,[DDD]
                                                                          ,[NUMERO]
                                                                      FROM [dbo].[TB_TELEFONE]
                                                                    ");
        }

        public void Excluir(Telefone a)
        {
             _acessoDataDapper.dbConnectiondbConnection.Query<Telefone>(@"
                      DELETE TB_TELEFONE WHERE TELEFONE_ID = @TELEFONE_ID ", a);
        }

        public void Inserir(Telefone a)
        {
            _acessoDataDapper.dbConnectiondbConnection.Query<Telefone>(@"
                      INSERT INTO TB_TELEFONE (TIPO_TELEFONE, DDD, NUMERO) VALUES (@TIPO_TELEFONE, @DDD, @NUMERO) ", new { a.tipo_Telefone, a.ddd, a.numero });
        }
    }
}
