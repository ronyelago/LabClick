using System;

namespace LabClick.Domain.Entities
{
    public class Laudo
    {
        public int Id { get; set; }
        public byte[] Documento { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Teste Teste { get; set; }
    }
}
