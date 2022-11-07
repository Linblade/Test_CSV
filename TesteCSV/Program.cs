using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using TesteCSV.Models;
using static System.Net.WebRequestMethods;

internal class Program
{
    private static void Main(string[] args)
    {

        //bool hasHeader = true; 
        var myPath = @"D:\Programacion\teste_ProvaAuvo\Arquivos_teste\Departamento de Operações Especiais-Abril-2022.csv";
        var reader = new StreamReader(myPath, Encoding.Latin1);
        var row = reader.ReadLine();
        var currentLine = row.Split(";");
        int positionCodigo = Array.FindIndex(currentLine, element => element.ToUpper().Contains("digo".ToUpper())),
            positionNome = Array.FindIndex(currentLine, element => element.ToUpper() == "Nome".ToUpper()),
            positionValorDaHora = Array.FindIndex(currentLine, element => element.ToUpper() == "Valor Hora".ToUpper()),
            positionData = Array.FindIndex(currentLine, element => element.ToUpper() == "Data".ToUpper()),
            positionHoraEntrada = Array.FindIndex(currentLine, element => element.ToUpper() == "Entrada".ToUpper()),
            positionHoraSaida = Array.FindIndex(currentLine, element => element.ToUpper() == "Saída".ToUpper()),
            positionAlmoco = Array.FindIndex(currentLine, element => element.ToUpper() == "Almoço".ToUpper());

        var lines = new List<AnaliseDTO>();
        bool[] isUsable = new bool[7];

        while (true)
        {
            Array.Clear(isUsable, 0, isUsable.Length);
            row = reader.ReadLine();
            if (row == null)
            {
                break;
            }

            currentLine = row.Split(";");
            var currentAlmoco = currentLine[positionAlmoco].Split(" - ");

            isUsable[0] = Int32.TryParse(currentLine[positionCodigo], out int tempCodigo);
            isUsable[1] = currentLine[positionNome].Trim() != "";
            isUsable[2] = decimal.TryParse(currentLine[positionValorDaHora].Replace("R$", "").Replace(" ", ""), out decimal tempValorDaHora);
            isUsable[3] = DateTime.TryParse($"{currentLine[positionData]} {currentLine[positionHoraEntrada]}", out DateTime tempHoraEntrada);
            isUsable[4] = DateTime.TryParse($"{currentLine[positionData]} {currentAlmoco[0]}", out DateTime tempHoraSaidaAlmoco);
            isUsable[5] = DateTime.TryParse($"{currentLine[positionData]} {currentAlmoco[1]}", out DateTime tempHoraRetornoAlmoco);
            isUsable[6] = DateTime.TryParse($"{currentLine[positionData]} {currentLine[positionHoraSaida]}", out DateTime tempHoraSaida);

            if (isUsable[0] && isUsable[1] && isUsable[2] && isUsable[3] && isUsable[4] && isUsable[5] && isUsable[6])
            {

                lines.Add(new AnaliseDTO()
                {
                    Codigo = tempCodigo,
                    Nome = currentLine[positionNome],
                    ValorDaHora = tempValorDaHora,
                    HoraEntrada = tempHoraEntrada,
                    HoraSaidaAlmoco = tempHoraSaidaAlmoco,
                    HoraRetornoAlmoco = tempHoraRetornoAlmoco,
                    HoraSaida = tempHoraSaida
                });
            }
        }

        // Control para ver listado de Model AnaliseDTO
        foreach (AnaliseDTO line in lines)
        {
            Console.WriteLine($"{line}");
        }





    }

}