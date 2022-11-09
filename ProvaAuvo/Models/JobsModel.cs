using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoRh.Models
{
    internal class JobsModel
    {

        public decimal ValorDaHora { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaidaAlmoco { get; set; }
        public DateTime HoraRetornoAlmoco { get; set; }
        public DateTime HoraSaida { get; set; }

        public override string ToString()
        {
            return $"{"Teste",-6} | {ValorDaHora,12} | {HoraEntrada,-16} | {HoraSaidaAlmoco,-16} | {HoraRetornoAlmoco,-16} | {HoraSaida,-16}";
        }
    }
}
