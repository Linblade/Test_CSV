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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Precisa definir uma pasta!");
            }
            else
            {
                try
                {
                    string[] files = checkBox1.Checked ? Directory.GetFiles(textBox1.Text, "*.csv", SearchOption.AllDirectories) : Directory.GetFiles(textBox1.Text, "*.csv");
                    foreach (string file in files)
                    {
                        string filename = Path.GetFullPath(file);
                        writeToTextBox2(filename);

                        toolStripProgressBar1.Value = toolStripProgressBar1.Value != 100 ? toolStripProgressBar1.Value + 50 : 0;
                    }
                    if (textBox2.Text.Trim() != "")
                    {
                        button1.Enabled = false;
                        button2.Enabled = true;
                    }
                    else
                    {
                        button1.Enabled = true;
                        button2.Enabled = false;
                    }
                    

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fInfo = new FileInfo(openFileDialog1.FileName);
                textBox1.Text = fInfo.DirectoryName;
                textBox2.Text = "";
                button1.Enabled = true;
                toolStripProgressBar1.Value = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            button1.Enabled = true;
            toolStripProgressBar1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lines = new List<AnaliseDTO>();
            var myPath = textBox2.Text.Replace("\r", "").Trim().Split('\n');
            var nomesArquivosDepartamentos = new List<string>();
            //decimal totalPagar = 0;
            //decimal totalDescontos = 0;
            //decimal totalExtras = 0;
            decimal totalPagar = 0;
            decimal totalDescontos = 0;
            decimal totalExtras = 0;
            textBox2.Text = "";
            button2.Enabled = false;
            toolStripProgressBar1.Value = 0;
            // int count = 0;
            writeToTextBox2("[");

            foreach (var path in myPath)
            {
                //count++;
                //writeToTextBox2(count.ToString());

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
                        // calculo de las horas diarias ordinarias

                        // calculo de las horas diarias extras

                        // calculo de las horas faltantes

                    }
                }

                var splitPath = path.Split('\\');
                //nomesArquivosDepartamentos.Add();
                var nome = splitPath[splitPath.Length - 1].Replace(".csv", "").Split('-');

                writeToTextBox2("   {");
                writeToTextBox2($@"      ""Departamento"":""{nome[0]}"",");
                writeToTextBox2($@"      ""MesVigencia"":""{nome[1]}"",");
                writeToTextBox2($@"      ""AnoVigencia"":{nome[2]},");
                writeToTextBox2($@"      ""TotalPagar"":""{totalPagar}"",");
                writeToTextBox2($@"      ""TotalDescontos"":{totalDescontos},");
                writeToTextBox2($@"      ""TotalExtras"":{totalExtras},");
                writeToTextBox2($@"      ""Funcionarios"":""[");
                writeToTextBox2("         {");

            }
            // Control para ver listado de Model AnaliseDTO
            //foreach (AnaliseDTO line in lines)
            //{
            //    writeToTextBox2($"{line}");
            //}

            // Preparar Arquivo JSON



            button3.Enabled = true;
        }
    }
}
