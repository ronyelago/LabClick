using LabClick.ViewModel.Validators;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabClick.ViewModel
{
    public class NovoPacienteViewModel
    {
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Gênero")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Sexo { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres")]
        public string Telefone { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        [DisplayName("CPF")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cpf { get; set; }

        [DateValidator(ErrorMessage = "Data inválida")]
        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataNascimento { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }
    }
}