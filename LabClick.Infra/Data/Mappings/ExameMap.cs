using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class ExameMap : EntityTypeConfiguration<Exame>
    {
        public ExameMap()
        {
            ToTable("Exames");

            HasKey(k => k.Id);

            Property(p => p.DataCadastro).IsOptional();
            Property(p => p.DataModificado).IsOptional();

            Property(p => p.Nome).
                IsRequired().
                HasMaxLength(150);

            Property(p => p.Descricao).
                IsRequired().
                HasMaxLength(700);
        }
    }
}
