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
    public class BairroDataDapper : IDataAdmin<Bairro>
    {
        AcessoDataDapper _acessoDataDapper = new AcessoDataDapper();
        public void Atualizar(Bairro a)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
                    UPDATE [dbo].[TB_BAIRRO]
                        SET [BAIRRO_NOME] =  @BAIRRO_NOME
                        WHERE BAIRRO_ID = @BAIRRO_ID", a);
        }

        public Bairro BuscarPorId(int Id)
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Bairro>(@"
                        SELECT[BAIRRO_ID]
                            ,[BAIRRO_NOME]
                        FROM[dbo].[TB_BAIRRO]
                where BAIRRO_NOME = @BAIRRO_NOME", Id).FirstOrDefault();
        }

        public IEnumerable<Bairro> BuscarTodos()
        {
            return _acessoDataDapper.dbConnectiondbConnection.Query<Bairro>(@"
                        SELECT[BAIRRO_ID]
                            ,[BAIRRO_NOME]
                        FROM[dbo].[TB_BAIRRO]");
        }

        public void Excluir(Bairro a)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
                                DELETE FROM [dbo].[TB_BAIRRO] where BAIRRO_ID = @BAIRRO_ID ", a.BAIRRO_ID);
        }

        public void Inserir(Bairro a)
        {
            _acessoDataDapper.dbConnectiondbConnection.Execute(@"
                        INSERT INTO [dbo].[TB_BAIRRO]
                            ([BAIRRO_NOME])
                        VALUES
                            (@BAIRRO_NOME)", new { a.BAIRRO_NOME });
        }
    }
}
