using System;

namespace LabClick.ViewModel
{
    public class ListaTesteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomePaciente { get; set; }
        public string NomeClinica { get; set; }
        public string Status { get; set; }
        public DateTime DataTeste { get; set; }
    }
}