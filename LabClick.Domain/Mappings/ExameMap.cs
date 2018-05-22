using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Domain.Mappings
{
    public class ExameMap : EntityTypeConfiguration<Exame>
    {
        public ExameMap()
        {
            ToTable("Exames");

            HasKey(k => k.Id);

            Property(p => p.Nome).
                IsRequired().
                HasMaxLength(150);

            Property(p => p.Descricao).
                IsRequired().
                HasMaxLength(300);
        }
    }
}
