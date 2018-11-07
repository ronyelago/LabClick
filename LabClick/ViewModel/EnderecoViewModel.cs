using System.ComponentModel.DataAnnotations;

namespace LabClick.ViewModel
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Favor preencher a Cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Favor preencher o Estado.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Favor preencher o Número da residência.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Favor preencher o Bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Favor preencher o nome da rua.")]
        public string Logradouro { get; set; }
    }
}