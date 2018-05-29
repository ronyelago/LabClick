using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class ResultadoMap : EntityTypeConfiguration<Resultado>
    {
        public ResultadoMap()
        {
            ToTable("Resultados");

            HasKey(k => k.Id);

            Property(p => p.Tabela).
                HasMaxLength(500);

            Property(p => p.Observacoes)
                .HasMaxLength(200);
        }
    }
}
