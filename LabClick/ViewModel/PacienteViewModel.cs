using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LabClick.Database;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabClick.ViewModel
{
    public class PacienteViewModel 
    {

        public int id { get; set; }
        public int id_clinica { get; set; }
        [Required(ErrorMessage = "Nome Paciente Obrigatorio")]
        public string nome_paciente { get; set; }
        [Required(ErrorMessage = "Obrigatorio informar o sexo")]
        public string sexo { get; set; }
        [Required(ErrorMessage = "Obrigatorio informar a Data de Nascimento")]
        public System.DateTime data_nascimento { get; set; }
        [Required(ErrorMessage = "Obrigatorio e-mail")]
        public string email { get; set; }
        [Required(ErrorMessage = "Obrigatorio Telefone")]
        public string telefone { get; set; }
        [Required(ErrorMessage = "Obrigatorio CPF")]
        public string cpf { get; set; }
        public string uf_cidade { get; set; }
        public Nullable<System.DateTime> data_inserido { get; set; }
        public Nullable<System.DateTime> data_modificado { get; set; }

    }
}