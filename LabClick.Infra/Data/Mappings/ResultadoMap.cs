using LabClick.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class ResultadoMap : EntityTypeConfiguration<Resultado>
    {
        public ResultadoMap()
        {
            ToTable("Resultados");

            HasKey(r => r.Id);

            //Gera uma chave primária composta (PK, FK)
            Property(p => p.Id)
                .HasColumnName("TesteId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(p => p.Tabela)
                .HasMaxLength(500);

            Property(p => p.Observacoes)
                .HasMaxLength(200);
        }
    }
}
