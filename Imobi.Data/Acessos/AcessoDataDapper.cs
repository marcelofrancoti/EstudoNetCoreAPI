using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Data.Acessos
{
    public class AcessoDataDapper
    {
        private IDbConnection _connection;

        public AcessoDataDapper()
        {
            _connection = new SqlConnection(BuscarConexaoIMOBI());
        }

        public IDbConnection dbConnectiondbConnection => _connection;


        public string BuscarConexaoIMOBI()
        {
            string nomeDoArquivo = @"C:\conexaoIMOBI.txt";
            if (File.Exists(nomeDoArquivo))
            {
                return File.ReadAllText(nomeDoArquivo);
            }
            else
            {
                System.Diagnostics.Process.Start(@"../Criar_Arquivo_Conxeao.bat");
                File.WriteAllText(nomeDoArquivo, "Data Source=DESKTOP-QUFJ40L;Initial Catalog=IMOBI_FIVE;Integrated Security=True; TrustServerCertificate=True;");
                return File.ReadAllText(nomeDoArquivo);
            }
        }
    }
}
