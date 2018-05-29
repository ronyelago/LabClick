using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class PacienteMap : EntityTypeConfiguration<Paciente>
    {
        public PacienteMap()
        {
            ToTable("Pacientes");

            HasKey(k => k.Id);

            Property(p => p.EnderecoId).
                IsOptional();

            Property(p => p.DataNascimento).
                IsOptional();

            Property(p => p.DataCadastro).
                IsOptional();

            Property(p => p.DataModificado).
                IsOptional();

            Property(p => p.Nome).
                IsRequired().
                HasMaxLength(150);

            Property(p => p.Sexo).
                IsRequired().
                HasMaxLength(10);

            Property(p => p.Email).
                IsOptional().
                HasMaxLength(100);

            Property(p => p.Telefone).
                IsOptional().
                HasMaxLength(30);

            Property(p => p.Cpf).
                IsRequired().
                HasMaxLength(20);
        }
    }
}
