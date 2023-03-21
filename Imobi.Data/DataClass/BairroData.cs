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
    public class BairroData
    {
        public static AcessoImobi _acessoImobi = new AcessoImobi();
        public static DataTable selectTodosBairro(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(@"SELECT[BAIRRO_ID]
                                                      ,[BAIRRO_NOME]
                                                  FROM[dbo].[TB_BAIRRO]", sqlConnection);

            var reader = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        public static DataTable selectBairro_Nome(string nome, SqlConnection con)
        {

            SqlCommand command = new SqlCommand(@"
                                                SELECT[BAIRRO_ID]
                                                      ,[BAIRRO_NOME]
                                                  FROM[dbo].[TB_BAIRRO]
                                            where BAIRRO_NOME = @BAIRRO_NOME
                                                
                                                    ", con);
            command.Parameters.Add(new SqlParameter("@BAIRRO_NOME", nome));

            var reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        public static bool InserirBairro(string NOME, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@"
                                            INSERT INTO [dbo].[TB_BAIRRO]
                                                        ([BAIRRO_NOME])
                                                    VALUES
                                                        (@BAIRRO_NOME)
                                                    ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@BAIRRO_NOME", NOME));

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
        public static bool DeletarTodosBairros(SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_BAIRRO] ", sqlConnection);
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

        public static bool DeletarBairro_ID(int id, SqlConnection sqlConnection)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1FTUK2Q;Initial Catalog=IMOBI_FIVE;Integrated Security=True");

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_BAIRRO] where BAIRRO_ID = @BAIRRO_ID ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@BAIRRO_ID", id));
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
        public static bool AtualizarBairro(int id, string nome, SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(@"
                                                        UPDATE [dbo].[TB_BAIRRO]
                                                           SET [BAIRRO_NOME] =  @BAIRRO_NOME
                                                         WHERE BAIRRO_ID = @BAIRRO_ID
                                                    ", sqlConnection);

            command.Parameters.Add(new SqlParameter("@BAIRRO_NOME", nome));
            command.Parameters.Add(new SqlParameter("@BAIRRO_ID", id));

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
