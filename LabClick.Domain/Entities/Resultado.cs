using System;

namespace LabClick.Domain.Entities
{
    public class Resultado
    {
        public int Id { get; set; }
        public string Laudo { get; set; }
        public byte[] Tabela { get; set; }
        public byte[] Documento { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Teste Teste { get; set; }
    }
}
