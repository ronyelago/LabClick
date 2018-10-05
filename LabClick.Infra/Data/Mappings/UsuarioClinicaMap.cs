using LabClick.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    class UsuarioClinicaMap : EntityTypeConfiguration<UsuarioClinica>
    {
        public UsuarioClinicaMap()
        {
            HasKey(r => r.ClinicaId);

            //Gera uma chave primária composta (PK, FK)
            Property(p => p.ClinicaId)
                .HasColumnName("ClinicaId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
