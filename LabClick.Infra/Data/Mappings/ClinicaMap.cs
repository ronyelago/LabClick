using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class ClinicaMap : EntityTypeConfiguration<Clinica>
    {
        public ClinicaMap()
        {
            ToTable("Clinicas");

            HasKey(t => t.Id);

            Property(p => p.EnderecoId).IsOptional();

            Property(p => p.DataCadastro).IsOptional();

            Property(p => p.DataModificado).IsOptional();

            Property(p => p.LaboratorioId).IsOptional();

            Property(c => c.Nome).
                IsRequired().
                HasMaxLength(150);

            Property(c => c.CNPJ).
                IsRequired().
                HasMaxLength(20);

            Property(c => c.Email).
                HasMaxLength(50);
        }
    }
}
