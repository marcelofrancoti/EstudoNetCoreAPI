using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Imobi.Data.Acessos
{
    public  class AcessoImobi
    {
       public  AcessoImobi()
        {   
        }

      
        public  SqlConnection AbrirConexao()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-1FTUK2Q;Initial Catalog=IMOBI_FIVE;Integrated Security=True; TrustServerCertificate=True");

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();

                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                    return sqlConnection;
                }
            }
            sqlConnection.Open();
            return sqlConnection;
        }

    }


   
}
