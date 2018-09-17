using System;

namespace LabClick.Domain.Entities
{
    public class Teste
    {
        public Teste()
        {
            DataCadastro = DateTime.Now;
            Status = "Aguardando análise";
        }

        public int Id { get; set; }
        public int ExameId { get; set; }
        public int ClinicaId { get; set; }
        public int PacienteId { get; set; }
        public int TesteImagemId { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public bool LaudoOk { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Exame Exame { get; set; }
        public virtual Clinica Clinica { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Laudo Laudo { get; set; }
        public virtual TesteImagem TesteImagem { get; set; }
    }
}
