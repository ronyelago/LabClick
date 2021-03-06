﻿using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuarios");

            HasKey(k => k.Id);

            Property(p => p.DataCadastro).IsOptional();

            Property(p => p.DataModificado).IsOptional();

            Property(p => p.Nome).
                IsRequired().
                HasMaxLength(150);

            Property(p => p.Email).
                IsOptional().
                HasMaxLength(100);

            Property(p => p.Perfil).
                IsRequired().
                HasMaxLength(50);
        }
    }
}
