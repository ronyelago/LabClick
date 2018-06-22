using System;

namespace LabClick.Domain.Entities
{
    public class Laudo
    {
        public int Id { get; set; }
        public string Resultado { get; set; }
        public byte[] Documento { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Teste Teste { get; set; }
    }
}
