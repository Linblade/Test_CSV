using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoRh.Models
{
    internal class ColaboradorModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        //Gerar IEnumerable<JobsModel>

        public override string ToString()
        {
            return $"{Codigo,-6} | {Nome,-20} | ";
        }
    }
}
