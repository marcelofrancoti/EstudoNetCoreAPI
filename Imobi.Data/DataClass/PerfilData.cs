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
    public class PerfilData
    {
        public static AcessoImobi _acessoImobi = new AcessoImobi();
        public static DataTable SelectTodosPerfil(SqlConnection sqlConnection)
        {
            //COMANDO A SER EXECUTADO NO BANCO
            SqlCommand sqlCommand = new SqlCommand(@"
                                                SELECT[PERFIL_ID]
                                                      ,[DESCRICAO]
                                                  FROM[dbo].[TB_PERFIL]", sqlConnection);
            //EXECUTAR LEITURA DO RETORNO DO BANCO 
            var reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            //CONVERSÃO DE READER PARA DATA TABLE PARA FACILITAR A LEITURA
            dt.Load(reader);

            return dt;
        }
        public static DataTable SelectPerfil_Descricao(string descricao, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(@"
                                                SELECT[PERFIL_ID]
                                                      ,[DESCRICAO]
                                                  FROM[dbo].[TB_PERFIL]
                                            where DESCRICAO = @DESCRICAO
                                                
                                                    ", con);
            command.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));

            var reader = command.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            return dt;
        }
        public static bool InserirPerfil(string descricao, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@"
                                            INSERT INTO [dbo].[TB_PERFIL]
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
        public static bool DeletarTodosPerfil(SqlConnection sqlConnection)
        {
            SqlConnection con = new SqlConnection("Data Source=MARCELODEV;Initial Catalog=IMOBI_FIVE;Integrated Security=True");

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_PERFIL] ", sqlConnection);
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
        public static bool DeletarPerfil_PorID(int id, SqlConnection sqlConnection)
        {
            SqlConnection con = new SqlConnection("Data Source=MARCELODEV;Initial Catalog=IMOBI_FIVE;Integrated Security=True");

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_PERFIL] where PERFIL_ID = @PERFIL_ID ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@PERFIL_ID", id));
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
        public static bool AtualizarPerfil(int id, string descricao, SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(@"
                                                        UPDATE [dbo].[TB_PERFIL]
                                                           SET [DESCRICAO] =  @DESCRICAO
                                                         WHERE PERFIL_ID = @PERFIL_ID
                                                    ", sqlConnection);

            command.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));
            command.Parameters.Add(new SqlParameter("@PERFIL_ID", id));

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
