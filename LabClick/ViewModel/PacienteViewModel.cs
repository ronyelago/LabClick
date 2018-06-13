using System;

namespace LabClick.ViewModel
{
    public class PacienteViewModel 
    {
        public int Id { get; set; }
        public int ClinicaId { get; set; }
        public int? EnderecoId { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataModificado { get; set; }

    }
}