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
        public decimal tempValorDaHora { get; set; }
        public DateTime tempHoraEntrada { get; set; }
        public DateTime tempHoraSaidaAlmoco { get; set; }
        public DateTime tempHoraRetornoAlmoco { get; set; }
        public DateTime tempHoraSaida { get; set; }

        private List<JobsModel> Jobs = new List<JobsModel>();

        public void AddJobs() 
        {
            Jobs.Add(new JobsModel()
            {
                //Codigo = tempCodigo,
                // Nome = currentLine[positionNome],
                ValorDaHora = tempValorDaHora,
                HoraEntrada = tempHoraEntrada,
                HoraSaidaAlmoco = tempHoraSaidaAlmoco,
                HoraRetornoAlmoco = tempHoraRetornoAlmoco,
                HoraSaida = tempHoraSaida
            });
        }

        public override string ToString()
        {
            return $"{Codigo,-6} | {Nome,-20} | ";
        }
    }
}
