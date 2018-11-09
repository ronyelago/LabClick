using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabClick.ViewModel
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo de 20 números")]
        [DisplayName("CEP")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cep { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo de 2 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "UF inválida")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string UF { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Numero { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Bairro { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [DisplayName("Rua")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Logradouro { get; set; }
    }
}