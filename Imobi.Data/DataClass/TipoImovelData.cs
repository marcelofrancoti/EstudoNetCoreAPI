using Imobi.Data.Acessos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Data.DataClass
{
    public class TipoImovelData
    {
        public static AcessoImobi _acessoImobi = new AcessoImobi();
        public static DataTable SelectTodosTipoImovel(SqlConnection sqlConnection)
        {
            //COMANDO A SER EXECUTADO NO BANCO
            SqlCommand sqlCommand = new SqlCommand(@"
                                                SELECT[TIPO_IMOVEL_ID]
                                                      ,[DESCRICAO]
                                                  FROM[dbo].[TB_TIPO_IMOVEL]", sqlConnection);
            //EXECUTAR LEITURA DO RETORNO DO BANCO 
            var reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            //CONVERSÃO DE READER PARA DATA TABLE PARA FACILITAR A LEITURA
            dt.Load(reader);

            return dt;
        }
        public static DataTable SelectTipoImovel_Descricao(string descricao, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(@"
                                                SELECT[TIPO_IMOVEL_ID]
                                                      ,[DESCRICAO]
                                                  FROM[dbo].[TB_TIPO_IMOVEL]
                                            where DESCRICAO = @DESCRICAO
                                                
                                                    ", con);
            command.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));

            var reader = command.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            return dt;
        }
        public static bool InserirTipoImovel(string descricao, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@"
                                            INSERT INTO [dbo].[TB_TIPO_IMOVEL]
                                                        ([DESCRICAO])
                                                    VALUES
                                                        (@DESCRICAO)
                                                    ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));

            var ok = command.ExecuteNonQuery();

            if (ok == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeletarTodosTipoImovel(SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_TIPO_IMOVEL] ", sqlConnection);
            var ok = command.ExecuteNonQuery();

            if (ok == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeletarTipoImovel_PorID(int id, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_TIPO_IMOVEL] where TIPO_IMOVEL_ID = @TIPO_IMOVEL_ID ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@TIPO_IMOVEL_ID", id));
            var ok = command.ExecuteNonQuery();

            if (ok == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool AtualizarTipoImovel(int id, string descricao, SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(@"
                                                        UPDATE [dbo].[TB_TIPO_IMOVEL]
                                                           SET [DESCRICAO] = @DESCRICAO]
                                                         WHERE TIPO_IMOVEL_ID = @TIPO_IMOVEL_ID
                                                    ", sqlConnection);

            command.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));
            command.Parameters.Add(new SqlParameter("@TIPO_IMOVEL_ID", id));

            var ok = command.ExecuteNonQuery();

            if (ok == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
