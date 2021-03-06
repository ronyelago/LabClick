﻿using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class LaboratorioMap : EntityTypeConfiguration<Laboratorio>
    {
        public LaboratorioMap()
        {
            ToTable("Laboratorios");

            HasKey(k => k.Id);

            Property(p => p.EnderecoId).
                IsOptional();

            Property(p => p.Nome).
                IsRequired().
                HasMaxLength(100);

            Property(p => p.Email).
                HasMaxLength(60);

            Property(p => p.DataCadastro).
                IsOptional();

            Property(p => p.DataModificado).
                IsOptional();
        }
    }
}
