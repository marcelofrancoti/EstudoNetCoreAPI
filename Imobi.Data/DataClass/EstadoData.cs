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
    public class EstadoData
    {
        public static AcessoImobi _acessoImobi = new AcessoImobi();
        public static DataTable SelectTodosEstado(SqlConnection sqlConnection)
        {
            //COMANDO A SER EXECUTADO NO BANCO
            SqlCommand sqlCommand = new SqlCommand(@"
                                                SELECT[ESTADO_ID]
                                                      ,[UF]
                                                      ,[DESCRICAO]
                                                  FROM[dbo].[TB_ESTADO]", sqlConnection);
            //EXECUTAR LEITURA DO RETORNO DO BANCO 
            var reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            //CONVERSÃO DE READER PARA DATA TABLE PARA FACILITAR A LEITURA
            dt.Load(reader);

            return dt;
        }
        public static DataTable SelectEstado_Uf(string uf, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(@"
                                                SELECT[ESTADO_ID]
                                                      ,[UF]
                                                      ,[DESCRICAO]
                                                  FROM[dbo].[TB_ESTADO]
                                            where UF = @UF
                                                
                                                    ", con);
            command.Parameters.Add(new SqlParameter("@UF", uf));

            var reader = command.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            return dt;
        }
        public static bool InserirEstado(string uf, string descricao, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@"
                                            INSERT INTO [dbo].[TB_ESTADO]
                                                        ([UF],[DESCRICAO])
                                                    VALUES
                                                        (@UF, @DESCRICAO)
                                                    ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@UF", uf));
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
        public static bool DeletarTodosEstado(SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_ESTADO] ", sqlConnection);
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
        public static bool DeletarEstado_PorID(int id, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_ESTADO] where ESTADO_ID = @ESTADO_ID ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@ESTADO_ID", id));
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
        public static bool AtualizarEstado(int id, string uf, string descricao, SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(@"
                                                        UPDATE [dbo].[TB_ESTADO]
                                                           SET [UF] = @UF
                                                           SET [DESCRICAO] =  @DESCRICAO
                                                         WHERE ESTADO_ID = @ESTADO_ID
                                                    ", sqlConnection);

            command.Parameters.Add(new SqlParameter("@UF", uf));
            command.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));
            command.Parameters.Add(new SqlParameter("@ESTADO_ID", id));

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
