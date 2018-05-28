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
            var str = File.ReadAllBytes(@"C:\Users\MfDev\Downloads\aindaBem.jpg");

            var Teste = new
            {
                ExameId = 1,
                ClinicaId = 3,
                PacienteId = 2,
                Imagem = str,
                Status = "deu bom!",
                DataCadastro = DateTime.Now
            };

            var serialized = JsonConvert.SerializeObject(Teste);

            HttpClient client = new HttpClient();
            Uri uri = new Uri(@"http://localhost:3000/testes");

            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var result = client.PostAsync(uri, content);
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

        }
    }
}
