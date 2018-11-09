using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabClick.ViewModel
{
    public class NovoPacienteViewModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Gênero")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Sexo { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cpf { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataNascimento { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }
    }
}