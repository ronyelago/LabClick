using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Enderecos");

            HasKey(k => k.Id);

            Property(p => p.Logradouro).HasMaxLength(100);
            Property(p => p.Cep).HasMaxLength(20);
            Property(p => p.Cidade).HasMaxLength(100);
            Property(p => p.Bairro).HasMaxLength(50);
            Property(p => p.UF).HasMaxLength(6);
        }
    }
}
