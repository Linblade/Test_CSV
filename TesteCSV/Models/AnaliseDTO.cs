using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCSV.Models
{
    internal class AnaliseDTO
    {
       
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal ValorDaHora { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaidaAlmoco { get; set; }
        public DateTime HoraRetornoAlmoco { get; set; }
        public DateTime HoraSaida { get; set; }

        public override string ToString()
        {
            return $"{Codigo,-4} | {Nome,-13} | {ValorDaHora, 9} | {HoraEntrada,-16} | {HoraSaidaAlmoco,-16} | {HoraRetornoAlmoco,-16} | {HoraSaida,-16}";
        }
    }
}
