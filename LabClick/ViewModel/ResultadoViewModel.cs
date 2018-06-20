using LabClick.Domain.Entities;
using System;

namespace LabClick.ViewModel
{
    public class ResultadoViewModel
    {
        public int Id { get; set; }
        public int ExameId { get; set; }
        public int TesteId { get; set; }
        public string Laudo { get; set; }
        public string Tabela { get; set; }
        public string Observacoes { get; set; }
        public string Documento { get; set; }
        public DateTime DataCadastro { get; set; }
        public Exame Exame { get; set; }
        public Teste Teste { get; set; }
    }
}