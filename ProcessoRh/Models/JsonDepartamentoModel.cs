using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoRh.Models
{
    internal class JsonDepartamentoModel
    {
        public string Nome { get; set; }
        public string MesVigencia { get; set; }
        public int AnoVigencia { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal TotalDescontos { get; set; }
        public decimal TotalExtras { get; set; }
        
      
        //Gerar IEnumerable<ColaboradoresModel>

        //Gerar Overrride ToString
    }
}
