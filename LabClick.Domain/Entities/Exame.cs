using System;

namespace LabClick.Domain.Entities
{
    public class Exame
    {
        public Exame()
        {
            DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int ClinicaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataModificado { get; set; }
        public virtual Clinica Clinica { get; set; }
    }
}
