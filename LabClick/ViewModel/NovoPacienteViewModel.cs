using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabClick.ViewModel
{
    public class NovoPacienteViewModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Favor preencher o nome do paciente")]
        public string Nome { get; set; }

        [DisplayName("Gênero")]
        [Required(ErrorMessage = "Favor preencher o gênero do paciente")]
        public string Sexo { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Favor preencher o e-mail do paciente")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Favor preencher o CPF do paciente")]
        public string Cpf { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Favor preencher a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }
    }
}