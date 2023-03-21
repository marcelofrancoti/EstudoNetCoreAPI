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
    public class FormaDePagamentoData
    {
        public static AcessoImobi _acessoImobi = new AcessoImobi();
        public static DataTable selectTodasFormaDePagamento(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(@"SELECT[FORMA_DE_PAGAMENTO_ID]
                                                      ,[DESCRICAO]
                                                  FROM[dbo].[TB_FORMA_DE_PAGAMENTO]", sqlConnection);

            var reader = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        public static DataTable selectFormaDePagamento_Descricao(string descricao, SqlConnection con)
        {

            SqlCommand command = new SqlCommand(@"
                                                SELECT[FORMA_DE_PAGAMENTO_ID]
                                                      ,[DESCRICAO]
                                                  FROM[dbo].[TB_FORMA_DE_PAGAMENTO]
                                            where DESCRICAO = @DESCRICAO
                                                
                                                    ", con);
            command.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));

            var reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        public static bool InserirFormaDePagamento(string DESCRICAO, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@"
                                            INSERT INTO [dbo].[TB_FORMA_DE_PAGAMENTO]
                                                        ([DESCRICAO])
                                                    VALUES
                                                        (@DESCRICAO)
                                                    ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@DESCRICAO", DESCRICAO));

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
        public static bool DeletarTodasFormaDePagamento(SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_FORMA_DE_PAGAMENTO] ", sqlConnection);
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

        public static bool DeletarFormaDePagamento_ID(int id, SqlConnection sqlConnection)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1FTUK2Q;Initial Catalog=IMOBI_FIVE;Integrated Security=True");

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_FORMA_DE_PAGAMENTO] where FORMA_DE_PAGAMENTO_ID = @FORMA_DE_PAGAMENTO_ID ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@FORMA_DE_PAGAMENTO_ID", id));
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
        public static bool AtualizarFormaDePagamento(int id, string descricao, SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(@"
                                                        UPDATE [dbo].[TB_FORMA_DE_PAGAMENTO]
                                                           SET [DESCRICAO] =  @DESCRICAO
                                                         WHERE FORMA_DE_PAGAMENTO_ID = @FORMA_DE_PAGAMENTO_ID
                                                    ", sqlConnection);

            command.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));
            command.Parameters.Add(new SqlParameter("@FORMA_DE_PAGAMENTO_ID", id));

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