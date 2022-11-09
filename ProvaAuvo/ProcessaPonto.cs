using ProcessoRh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ProcessoRh
{
    public partial class ProcessaPonto : Form
    {
        public ProcessaPonto()
        {
            InitializeComponent();
        }

        private void writeToTextBox2(string t)
        {
            textBox2.Text = textBox2.Text + t + "\r\n";
        }

        private void lerArquivos_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text == "")
            {
                MessageBox.Show("Precisa definir uma rota ou pasta!");
            }
            else
            {
                try
                {
                    string[] files = useSubFolders.Checked ? Directory.GetFiles(textBoxPath.Text, "*.csv", SearchOption.AllDirectories) : Directory.GetFiles(textBoxPath.Text, "*.csv");
                    foreach (string file in files)
                    {
                        string filename = Path.GetFullPath(file);
                        writeToTextBox2(filename);
                    }
                    if (textBox2.Text.Trim() != "")
                    {
                        lerArquivos.Enabled = false;
                        processarCsv.Enabled = true;
                    }
                    else
                    {
                        lerArquivos.Enabled = true;
                        processarCsv.Enabled = false;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }

        }

        private void textBoxPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fInfo = new FileInfo(openFileDialog1.FileName);
                textBoxPath.Text = fInfo.DirectoryName;
                textBox2.Text = string.Empty;
                lerArquivos.Enabled = true;
                processarCsv.Enabled = false;
            }
        }

        private void useSubFolders_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            lerArquivos.Enabled = true;
            processarCsv.Enabled = false;
        }

        
        private void processarCsv_Click(object sender, EventArgs e)
        {
            var currentJobs = new List<JobsModel>();
            var myPath = textBox2.Text.Replace("\r", "").Trim().Split('\n');
            var nomesArquivosDepartamentos = new List<string>();
            textBox2.Text = string.Empty;
            processarCsv.Enabled = false;


            foreach (var path in myPath)
            {


                var reader = new StreamReader(path, Encoding.Default);
                var row = reader.ReadLine();
                var currentLine = row.Split(';');
                int positionCodigo = Array.FindIndex(currentLine, element => element.ToUpper().Contains("digo".ToUpper())),
                    positionNome = Array.FindIndex(currentLine, element => element.ToUpper() == "Nome".ToUpper()),
                    positionValorDaHora = Array.FindIndex(currentLine, element => element.ToUpper() == "Valor Hora".ToUpper()),
                    positionData = Array.FindIndex(currentLine, element => element.ToUpper() == "Data".ToUpper()),
                    positionHoraEntrada = Array.FindIndex(currentLine, element => element.ToUpper() == "Entrada".ToUpper()),
                    positionHoraSaida = Array.FindIndex(currentLine, element => element.ToUpper() == "Saída".ToUpper()),
                    positionAlmoco = Array.FindIndex(currentLine, element => element.ToUpper() == "Almoço".ToUpper());

                bool[] isUsable = new bool[7];

                while (true)
                {
                    Array.Clear(isUsable, 0, isUsable.Length);
                    row = reader.ReadLine();
                    if (row == null)
                    {
                        break;
                    }

                    currentLine = row.Split(';');
                    var currentAlmoco = currentLine[positionAlmoco].Split('-');

                    isUsable[0] = Int32.TryParse(currentLine[positionCodigo], out int tempCodigo);
                    isUsable[1] = currentLine[positionNome].Trim() != "";
                    isUsable[2] = decimal.TryParse(currentLine[positionValorDaHora].Replace("R$", "").Replace(" ", ""), out decimal tempValorDaHora);
                    isUsable[3] = DateTime.TryParse($"{currentLine[positionData]} {currentLine[positionHoraEntrada]}", out DateTime tempHoraEntrada);
                    isUsable[4] = DateTime.TryParse($"{currentLine[positionData]} {currentAlmoco[0].Trim()}", out DateTime tempHoraSaidaAlmoco);
                    isUsable[5] = DateTime.TryParse($"{currentLine[positionData]} {currentAlmoco[1].Trim()}", out DateTime tempHoraRetornoAlmoco);
                    isUsable[6] = DateTime.TryParse($"{currentLine[positionData]} {currentLine[positionHoraSaida]}", out DateTime tempHoraSaida);

                    if (isUsable[0] && isUsable[1] && isUsable[2] && isUsable[3] && isUsable[4] && isUsable[5] && isUsable[6])
                    {

                        currentJobs.Add(new JobsModel()
                        {
                            //Codigo = tempCodigo,
                            // Nome = currentLine[positionNome],
                            ValorDaHora = tempValorDaHora,
                            HoraEntrada = tempHoraEntrada,
                            HoraSaidaAlmoco = tempHoraSaidaAlmoco,
                            HoraRetornoAlmoco = tempHoraRetornoAlmoco,
                            HoraSaida = tempHoraSaida
                        });
                        // calculo de las horas diarias ordinarias

                        // calculo de las horas diarias extras

                        // calculo de las horas faltantes

                    }
                }

                var splitPath = path.Split('\\');
                nomesArquivosDepartamentos.Add(splitPath[splitPath.Length - 1].Replace(".csv", ""));

                // Control para ver listado de Model AnaliseDTO
                foreach (JobsModel job in currentJobs)
                {
                    writeToTextBox2($"{job}");
                }

            }

            // Preparar Arquivo JSON



            gerarJson.Enabled = true;
        }

    }
}

