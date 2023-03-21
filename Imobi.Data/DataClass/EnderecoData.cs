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
    public class EnderecoData
    {
        public static AcessoImobi _acessoImobi = new AcessoImobi();
        public static DataTable SelectTodosEnderecos(SqlConnection sqlConnection)
        {
            //COMANDO A SER EXECUTADO NO BANCO
            SqlCommand sqlCommand = new SqlCommand(@"
                                                SELECT[ENDERECO_ID]
                                                      ,[CIDADE_ID]
                                                      ,[ESTADO_ID]
                                                      ,[BAIRRO_ID]
                                                      ,[ENDERECO_CEP]
                                                      ,[NOME_RUA]
                                                      ,[ENDERECO_NUMERO]
                                                  FROM[dbo].[TB_ENDERECO]", sqlConnection);
            //EXECUTAR LEITURA DO RETORNO DO BANCO 
            var reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            //CONVERSÃO DE READER PARA DATA TABLE PARA FACILITAR A LEITURA
            dt.Load(reader);

            return dt;
        }
        public static DataTable SelectEndereco_Cep(int cep, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(@"
                                             SELECT[ENDERECO_ID]
                                                      ,[CIDADE_ID]
                                                      ,[ESTADO_ID]
                                                      ,[BAIRRO_ID]
                                                      ,[ENDERECO_CEP]
                                                      ,[NOME_RUA]
                                                      ,[ENDERECO_NUMERO]
                                                  FROM[dbo].[TB_ENDERECO]
                                            where ENDERECO_CEP = @ENDERECO_CEP
                                                ", con);
            command.Parameters.Add(new SqlParameter("@ENDERECO_CEP", cep));

            var reader = command.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            return dt;
        }
        public static bool InserirEndereco(int cep, string nomeRua, int numero, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@"
                                            INSERT INTO [dbo].[TB_ENDERECO]
                                                        ([ENDERECO_CEP],[NOME_RUA],[ENDERECO_NUMERO])
                                                    VALUES
                                                        (@ENDERECO_CEP, @NOME_RUA, @ENDERECO_NUMERO)
                                                    ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@ENDERECO_CEP", cep));
            command.Parameters.Add(new SqlParameter("@NOME_RUA", nomeRua));
            command.Parameters.Add(new SqlParameter("@ENDERECO_NUMERO", numero));

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
        public static bool DeletarTodosEnderecos(SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_ENDERECO] ", sqlConnection);
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
        public static bool DeletarEnderecos_PorID(int id, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_ENDERECO] where ENDERECO_ID = @ENDERECO_ID ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@ENDERECO_ID", id));
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
        public static bool AtualizarEndereco(int id, int cidadeId, int estadoId, int bairroId, int cep, string nomeRua, int numero, SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(@"
                                                        UPDATE [dbo].[TB_ENDERECO]
                                                           SET [CIDADE_ID] =  @CIDADE_ID
                                                           SET [ESTADO_ID] =  @ESTADO_ID
                                                           SET [BAIRRO_ID] =  @BAIRRO_ID
                                                           SET [ENDERECO_CEP] =  @ENDERECO_CEP
                                                           SET [NOME_RUA] = @NOME_RUA
                                                           SET [ENDERECO_NUMERO] =  @ENDERECO_NUMERO
                                                         WHERE ENDERECO_ID = @ENDERECO_ID
                                                    ", sqlConnection);

            command.Parameters.Add(new SqlParameter("@ENDERECO_ID", id));
            command.Parameters.Add(new SqlParameter("@ESTADO_ID", estadoId));
            command.Parameters.Add(new SqlParameter("@CIDADE_ID", cidadeId));
            command.Parameters.Add(new SqlParameter("@BAIRRO_ID", bairroId));
            command.Parameters.Add(new SqlParameter("@ENDERECO_CEP", cep));
            command.Parameters.Add(new SqlParameter("@NOME_RUA", nomeRua));
            command.Parameters.Add(new SqlParameter("@ENDERECO_NUMERO", numero));

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
