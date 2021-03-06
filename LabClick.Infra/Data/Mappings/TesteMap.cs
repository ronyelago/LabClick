﻿using LabClick.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class TesteMap : EntityTypeConfiguration<Teste>
    {
        public TesteMap()
        {
            ToTable("Testes");

            HasKey(k => k.Id);

            Property(p => p.Id).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(p => p.Laudo).WithRequired(t => t.Teste);

            Property(p => p.DataCadastro).IsOptional();
            Property(p => p.Code).IsOptional();
            Property(p => p.VistoClinica).IsOptional();
            Property(p => p.VistoLab).IsOptional();
            Property(p => p.Code).HasMaxLength(100);
            Property(p => p.Status).IsRequired().HasMaxLength(50);
            Property(p => p.Observacoes).HasMaxLength(200);
            Property(p => p.ResultadoDetalhes).IsOptional();
        }
    }
}
