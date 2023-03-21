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
    public class ImovelData
    {
        public static AcessoImobi _acessoImobi = new AcessoImobi();
        public static DataTable SelectTodosImovel(SqlConnection sqlConnection)
        {
            //COMANDO A SER EXECUTADO NO BANCO
            SqlCommand sqlCommand = new SqlCommand(@"
                                                SELECT[IMOVEL_ID]
                                                      ,[TIPO_IMOVEL_ID]
                                                      ,[PESSOA_ID]
                                                      ,[ENDERECO_ID]
                                                      ,[VALOR]
                                                      ,[QTDE_DORMITORIOS]
                                                      ,[QTDE_BANHEIROS]
                                                      ,[QTDE_SALAS]
                                                      ,[QTDE_COZINHAS]
                                                      ,[VAGAS_GARAGEM]
                                                      ,[DESCRICAO_COMODOS_EXTRAS]
                                                      ,[AREA_TERRENO]
                                                      ,[AREA_CONSTRUIDA]
                                                      ,[MATRICULA]
                                                      ,[COD_AGUA]
                                                      ,[COD_ENERGIA]
                                                  FROM[dbo].[TB_IMOVEL]", sqlConnection);
            //EXECUTAR LEITURA DO RETORNO DO BANCO 
            var reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            //CONVERSÃO DE READER PARA DATA TABLE PARA FACILITAR A LEITURA
            dt.Load(reader);

            return dt;
        }
        public static DataTable SelectImovel_EnderecoId(int id, SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(@"
                                                SELECT[IMOVEL_ID]
                                                      ,[TIPO_IMOVEL_ID]
                                                      ,[PESSOA_ID]
                                                      ,[ENDERECO_ID]
                                                      ,[VALOR]
                                                      ,[QTDE_DORMITORIOS]
                                                      ,[QTDE_BANHEIROS]
                                                      ,[QTDE_SALAS]
                                                      ,[QTDE_COZINHAS]
                                                      ,[VAGAS_GARAGEM]
                                                      ,[DESCRICAO_COMODOS_EXTRAS]
                                                      ,[AREA_TERRENO]
                                                      ,[AREA_CONSTRUIDA]
                                                      ,[MATRICULA]
                                                      ,[COD_AGUA]
                                                      ,[COD_ENERGIA]
                                                  FROM[dbo].[TB_IMOVEL]
                                                  WHERE IMOVEL_ID = @IMOVEL_ID", sqlConnection);
            command.Parameters.Add(new SqlParameter("@IMOVEL_ID", id));


            var reader = command.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            return dt;
        }
        public static bool InserirImovel(Imovel imovel, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@"
                                            INSERT INTO [dbo].[TB_IMOVEL]
                                                        ([IMOVEL_ID]
                                                      ,[TIPO_IMOVEL_ID]
                                                      ,[PESSOA_ID]
                                                      ,[ENDERECO_ID]
                                                      ,[VALOR]
                                                      ,[QTDE_DORMITORIOS]
                                                      ,[QTDE_BANHEIROS]
                                                      ,[QTDE_SALAS]
                                                      ,[QTDE_COZINHAS]
                                                      ,[VAGAS_GARAGEM]
                                                      ,[DESCRICAO_COMODOS_EXTRAS]
                                                      ,[AREA_TERRENO]
                                                      ,[AREA_CONSTRUIDA]
                                                      ,[MATRICULA]
                                                      ,[COD_AGUA]
                                                      ,[COD_ENERGIA])
                                                    VALUES
                                                        (@IMOVEL_ID, @TIPO_IMOVEL_ID, @PESSOA_ID, @ENDERECO_ID, @VALOR, @QTDE_DORMITORIOS, @QTDE_BANHEIROS
                                                         @QTDE_SALAS, @QTDE_COZINHAS, @VAGAS_GARAGEM, @DESCRICAO_COMODOS_EXTRAS, @AREA_TERRENO, @AREA_CONSTRUIDA
                                                         @MATRICULA, @COD_AGUA, @COD_ENERGIA)
                                                    ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@IMOVEL_ID", imovel.IMOVEL_ID));
            command.Parameters.Add(new SqlParameter("@TIPO_IMOVEL_ID", imovel.TIPO_IMOVEL_ID));
            command.Parameters.Add(new SqlParameter("@PESSOA_ID", imovel.PESSOA_ID));
            command.Parameters.Add(new SqlParameter("@ENDERECO_ID", imovel.ENDERECO_ID));
            command.Parameters.Add(new SqlParameter("@VALOR", imovel.VALOR));
            command.Parameters.Add(new SqlParameter("@QTDE_DORMITORIOS", imovel.QTDE_DORMITORIOS));
            command.Parameters.Add(new SqlParameter("@QTDE_BANHEIROS", imovel.QTDE_BANHEIROS));
            command.Parameters.Add(new SqlParameter("@QTDE_SALAS", imovel.QTDE_SALAS));
            command.Parameters.Add(new SqlParameter("@QTDE_COZINHAS", imovel.QTDE_COZINHA));
            command.Parameters.Add(new SqlParameter("@VAGAS_GARAGEM", imovel.VAGAS_GARAGEM));
            command.Parameters.Add(new SqlParameter("@DESCRICAO_COMODOS_EXTRAS", imovel.DESCRICAO_COMODOS_EXTRAS));
            command.Parameters.Add(new SqlParameter("@AREA_TERRENO", imovel.AREA_TERRENO));
            command.Parameters.Add(new SqlParameter("@AREA_CONSTRUIDA", imovel.AREA_CONSTRUIDA));
            command.Parameters.Add(new SqlParameter("@MATRICULA", imovel.MATRICULA));
            command.Parameters.Add(new SqlParameter("@COD_AGUA", imovel.COD_AGUA));
            command.Parameters.Add(new SqlParameter("@COD_ENERGIA", imovel.COD_ENERGIA));

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
        public static bool DeletarTodosImoveis(SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_IMOVEL] ", sqlConnection);
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
        public static bool DeletarImovel_PorID(int id, SqlConnection sqlConnection)
        {

            SqlCommand command = new SqlCommand(@" DELETE FROM [dbo].[TB_IMOVEL] where IMOVE_ID = @IMOVEL_ID ", sqlConnection);
            command.Parameters.Add(new SqlParameter("@IMOVEL_ID", id));
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
        public static bool AtualizarImoveis(Imovel imovel, SqlConnection sqlConnection)
        {
            SqlCommand command = new SqlCommand(@"
                                                        UPDATE [dbo].[TB_IMOVEL]
                                                           SET [VALOR] = @VALOR
                                                      [QTDE_DORMITORIOS] = @QTDE_DORMITORIOS
                                                      [QTDE_BANHEIROS] = @QTDE_BANHEIROS
                                                      [QTDE_SALAS] = @QTDE_SALAS
                                                      [QTDE_COZINHAS] = @QTDE_COZINHAS
                                                      [VAGAS_GARAGEM] = @VAGAS_GARAGEM
                                                      [DESCRICAO_COMODOS_EXTRAS] = @DESCRICAO_COMODOS_EXTRAS
                                                      [AREA_TERRENO] = @AREA_TERRENO
                                                      [AREA_CONSTRUIDA] = @AREA_CONSTRUIDA
                                                      [MATRICULA] = @MATRICULA
                                                      [COD_AGUA] = @COD_AGUA
                                                      [COD_ENERGIA] = @COD_ENERGIA
                                                         WHERE IMOVEL_ID = @IMOVEL_ID
                                                    ", sqlConnection);

            command.Parameters.Add(new SqlParameter("@IMOVEL_ID", imovel.IMOVEL_ID));
            command.Parameters.Add(new SqlParameter("@VALOR", imovel.VALOR));
            command.Parameters.Add(new SqlParameter("@QTDE_DORMITORIOS", imovel.QTDE_DORMITORIOS));
            command.Parameters.Add(new SqlParameter("@QTDE_BANHEIROS", imovel.QTDE_BANHEIROS));
            command.Parameters.Add(new SqlParameter("@QTDE_SALAS", imovel.QTDE_SALAS));
            command.Parameters.Add(new SqlParameter("@QTDE_COZINHAS", imovel.QTDE_COZINHA));
            command.Parameters.Add(new SqlParameter("@VAGAS_GARAGEM", imovel.VAGAS_GARAGEM));
            command.Parameters.Add(new SqlParameter("@DESCRICAO_COMODOS_EXTRAS", imovel.DESCRICAO_COMODOS_EXTRAS));
            command.Parameters.Add(new SqlParameter("@AREA_TERRENO", imovel.AREA_TERRENO));
            command.Parameters.Add(new SqlParameter("@AREA_CONSTRUIDA", imovel.AREA_CONSTRUIDA));
            command.Parameters.Add(new SqlParameter("@MATRICULA", imovel.MATRICULA));
            command.Parameters.Add(new SqlParameter("@COD_AGUA", imovel.COD_AGUA));
            command.Parameters.Add(new SqlParameter("@COD_ENERGIA", imovel.COD_ENERGIA));

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