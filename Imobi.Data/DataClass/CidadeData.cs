using Imobi.Data.Acessos;
using Imobi.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Data.DataClass
{
    public class CidadeData
    {
        public static AcessoImobi _acessoImobi = new AcessoImobi();
        public static DataTable SelectTodasCidades(SqlConnection sqlConnection)
        {
            //COMANDO A SER EXECUTADO NO BANCO
            SqlCommand sqlCommand = new SqlCommand(@"
                                                SELECT[CIDADE_ID]
                                                      ,[NOME_CIDADE]
                                                      ,[ESTADO_ID]
                                                  FROM[dbo].[TB_CIDADE]", sqlConnection);
            //EXECUTAR LEITURA DO RETORNO DO BANCO 
            var reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            //CONVERSÃO DE READER PARA DATA TABLE PARA FACILITAR A LEITURA
            dt.Load(reader);

            return dt;
        }
        public static DataTable SelectCidade_Nome(string nomeCidade, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(@"
                                                SELECT[CIDADE_ID]
                                                      ,[NOME_CIDADE]
                                                      ,[ESTADO_ID]
                                                  FROM[dbo].[TB_CIDADE]
                                            where NOME_CIDADE = @NOME_CIDADE
                                                
                                                    ", con);
            command.Parameters.Add(new SqlParameter("@NOME_CIDADE", nomeCidade));

            var reader = command.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            return dt;
        }
        public static bool InserirCidade(Cidade cidade, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@"
                                            INSERT INTO [dbo].[TB_CIDADE]
                                                        ([NOME_CIDADE], ESTADO_ID)
                                                    VALUES
                                                        (@NOME_CIDADE, @ESTADO_ID)
                                                    ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@NOME_CIDADE", cidade.NOME_CIDADE));
            command.Parameters.Add(new SqlParameter("@ESTADO_ID", cidade.ESTADO_ID));

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
        public static bool DeletarTodasCidades(SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_CIDADE] ", sqlConnection);
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
        public static bool DeletarCidades_PorID(int id, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_CIDADE] where CIDADE_ID = @CIDADE_ID ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@CIDADE_ID", id));
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
        public static bool AtualizarCidade(int id, string nomeCidade, int estadoId, SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(@"
                                                        UPDATE [dbo].[TB_CIDADE]
                                                           SET [NOME_CIDADE] = @NOME_CIDADE]
                                                           SET [ESTADO_ID] =  @ESTADO_ID
                                                         WHERE CIDADE_ID = @CIDADE_ID
                                                    ", sqlConnection);

            command.Parameters.Add(new SqlParameter("@NOME_CIDADE", nomeCidade));
            command.Parameters.Add(new SqlParameter("@ESTADO_ID", estadoId));
            command.Parameters.Add(new SqlParameter("@CIDADE_ID", id));

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
