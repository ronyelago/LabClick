using System;

namespace LabClick.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public int ClinicaId { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataModificado { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Clinica Clinica { get; set; }
    }
}
