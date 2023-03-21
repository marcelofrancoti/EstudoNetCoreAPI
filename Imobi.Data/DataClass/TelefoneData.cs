using Imobi.Data.Acessos;
using Imobi.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Imobi.Data.DataClass
{
    public class TelefoneData
    {
        public static AcessoImobi acessoImobi = new AcessoImobi();

        public static DataTable SelectTodosTelefone(SqlConnection sqlConection)
        {
            // COMANDO PARA SER EXECUTADO NO BANCO
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [TELEFONE_ID]
                                                  ,[TIPO_TELEFONE]
                                                  ,[DDD]
                                                  ,[NUMERO]
                                              FROM [dbo].[TB_TELEFONE]", sqlConection);
            // EXECUTAR A LEITURA DO RETORNO DO BANCO DE DADOS
            var reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            // CONVERSÃO DO READER PARA DATABLE ( FACILITAR A LEITURA )
            dt.Load(reader);

            return dt;
        }
        public static DataTable SelectTelefone_DDDTelefone(Telefone telefone, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(@"
                                               SELECT [TELEFONE_ID]
                                                  ,[TIPO_TELEFONE]
                                                  ,[DDD]
                                                  ,[NUMERO]
                                              FROM [dbo].[TB_TELEFONE]
                                              WHERE DDD = @DDD AND NUMERO = @NUMERO
                                                
                                                    ", con);
            command.Parameters.Add(new SqlParameter("@DDD", telefone.ddd));
            command.Parameters.Add(new SqlParameter("@NUMERO", telefone.numero));

            var reader = command.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            return dt;
        }
    }
}

