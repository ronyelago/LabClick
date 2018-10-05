using LabClick.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    class UsuarioLaboratorioMap : EntityTypeConfiguration<UsuarioLaboratorio>
    {
        public UsuarioLaboratorioMap()
        {
            HasKey(r => r.LaboratorioId);

            //Gera uma chave primária composta (PK, FK)
            Property(p => p.LaboratorioId)
                .HasColumnName("LaboratorioId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
