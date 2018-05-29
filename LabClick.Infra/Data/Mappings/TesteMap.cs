using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class TesteMap : EntityTypeConfiguration<Teste>
    {
        public TesteMap()
        {
            ToTable("Testes");

            HasKey(k => k.Id);

            Property(p => p.DataCadastro).IsOptional();

            Property(p => p.Status).
                IsRequired().
                HasMaxLength(50);
        }
    }
}
