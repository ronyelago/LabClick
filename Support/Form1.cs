using LabClick.Domain.Entities;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = txtGet.Text;
            var jsonTeste = Senders.GetTesteById(url);
            Teste teste = JsonConvert.DeserializeObject<Teste>(jsonTeste);

            pictureBox.Image = ImageControl.ConvertByteToImage(teste.Imagem);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            var str = File.ReadAllBytes(txtPost.Text);

            var Teste = new
            {
                ExameId = 1,
                ClinicaId = 1,
                PacienteId = 1,
                Imagem = str,
                Status = "Em análise",
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
    }
}
