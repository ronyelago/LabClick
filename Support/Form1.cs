using LabClick.Domain.Entities;
using LabClick.Infra.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Support
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            var Teste = new
            {
                ExameId = int.Parse(tboExameId.Text),
                ClinicaId = int.Parse(tboClinicaId.Text),
                PacienteId = int.Parse(tboPacienteId.Text),
                Imagem = ImageControl.ConvertFileToByte(pbImagemTeste),
                Status = tboStatus.Text,
                DataCadastro = DateTime.Now
            };

            var serialized = JsonConvert.SerializeObject(Teste);

            HttpClient client = new HttpClient();
            Uri uri = new Uri(@"http://apilabclick.mflogic.com.br/teste/testes");

            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var result = client.PostAsync(uri, content);

            if (result.Result.IsSuccessStatusCode)
            {
                MessageBox.Show("Deu bom.");
            }
            else
            {
                MessageBox.Show("Deu ruim.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSeed_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ImageControl.SelectImage(pbImagemTeste);
        }
    }
}
