using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Entity
{
    public class Imovel
    {
        public int IMOVEL_ID { get; set; }
        public int TIPO_IMOVEL_ID { get; set; }
        public int PESSOA_ID { get; set; }
        public int ENDERECO_ID { get; set; }
        public double VALOR { get; set; }
        public int QTDE_DORMITORIOS { get; set; }
        public int QTDE_BANHEIROS { get; set; }
        public int QTDE_SALAS { get; set; }
        public int QTDE_COZINHA { get; set; }
        public int VAGAS_GARAGEM { get; set; }
        public string DESCRICAO_COMODOS_EXTRAS { get; set; }
        public double AREA_TERRENO { get; set; }
        public double AREA_CONSTRUIDA { get; set; }
        public int MATRICULA { get; set; }
        public int COD_AGUA { get; set; }
        public int COD_ENERGIA { get; set; }
    }
}
