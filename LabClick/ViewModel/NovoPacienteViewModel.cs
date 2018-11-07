using System;
using System.ComponentModel.DataAnnotations;

namespace LabClick.ViewModel
{
    public class NovoPacienteViewModel
    {
        [Required(ErrorMessage = "Favor preencher o nome do paciente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor preencher o gênero do paciente")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Favor preencher o e-mail do paciente")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [Required(ErrorMessage = "Favor preencher o CPF do paciente")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Favor preencher a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }
    }
}