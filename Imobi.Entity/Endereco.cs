using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Entity
{
    public class Endereco
    {
        public int ENDERECO_ID { get; set; }
        public int CIDADE_ID { get; set; }
        public int ESTADO_ID { get; set; }
        public int BAIRRO_ID { get; set; }
        public int ENDERECO_CEP { get; set; }
        public string NOME_RUA { get; set; }
        public int ENDERECO_NUMERO { get; set; }
    }
}
