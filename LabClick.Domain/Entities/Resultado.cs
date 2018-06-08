using System;

namespace LabClick.Domain.Entities
{
    public class Resultado
    {
        public int Id { get; set; }
        public int ExameId { get; set; }
        public int TesteId { get; set; }
        public byte[] Laudo { get; set; }
        public string Tabela { get; set; }
        public string Observacoes { get; set; }
        public byte[] Documento { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Exame Exame { get; set; }
        public virtual Teste Teste { get; set; }
    }
}
