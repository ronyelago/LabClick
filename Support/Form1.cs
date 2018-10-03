using Newtonsoft.Json;
using System;
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

        private void btnPost_Click(object sender, EventArgs e)
        {
            var Laboratorio = new
            {
                EnderecoId = int.Parse(tboEnderecoId.Text),
                Nome = tboNome.Text,
                Email = tboEmail.Text,
                ImagemLogo = ImageControl.ConvertFileToByte(pbImagemLogo),
                ImagemFooter = ImageControl.ConvertFileToByte(pbImagemFooter),
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            var serialized = JsonConvert.SerializeObject(Laboratorio);

            HttpClient client = new HttpClient();
            Uri uri = new Uri(@"http://localhost:52434/laboratorio/add");

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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ImageControl.SelectImage(pbImagemLogo);
        }

        private void btnSelectImagemFooter_Click(object sender, EventArgs e)
        {
            ImageControl.SelectImage(pbImagemFooter);
        }
    }
}
