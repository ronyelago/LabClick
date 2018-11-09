using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabClick.ViewModel
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string UF { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Bairro { get; set; }

        [DisplayName("Rua")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Logradouro { get; set; }
    }
}