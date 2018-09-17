namespace LabClick.Domain.Entities
{
    public class TesteImagem
    {
        public int Id { get; set; }
        public int TesteId { get; set; }
        public byte[] Imagem { get; set; }
        public Teste Teste { get; set; }
    }
}
