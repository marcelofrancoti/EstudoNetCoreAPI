using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobi.Entity
{
    public class Telefone
    {
        public int telefone_ID { get; set; }
        public string tipo_Telefone { get; set; }
        public int ddd { get; set; }
        public int numero { get; set; }
    }
}
