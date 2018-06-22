using LabClick.Domain.Entities;
using System;

namespace LabClick.ViewModel
{
    public class TesteViewModel
    {
        public int Id { get; set; }
        public int ExameId { get; set; }
        public int ClinicaId { get; set; }
        public int PacienteId { get; set; }
        public byte[] Imagem { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public string DataTeste
        {
            get { return this.DataCadastro.ToShortDateString(); }
        }

        public string HoraTeste
        {
            get { return this.DataCadastro.ToShortTimeString(); }
        }

        public Clinica  Clinica { get; set; }
        public Paciente Paciente { get; set; }
        public Exame Exame { get; set; }
        public Laudo Laudo { get; set; }
    }
}