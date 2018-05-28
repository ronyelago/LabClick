using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
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
            var Teste = new
            {
                ExameId = 1,
                ClinicaId = 3,
                PacienteId = 2,
                Status = "deu bom!",
                DataCadastro = DateTime.Now
            };

            var serialized = JsonConvert.SerializeObject(Teste);

            HttpClient client = new HttpClient();
            Uri uri = new Uri(@"http://localhost:52434/testes");

            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var result = client.PostAsync(uri, content);
        }
    }
}
