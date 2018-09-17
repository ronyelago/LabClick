using LabClick.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LabClick.Infra.Data.Mappings
{
    public class TesteImagemMap : EntityTypeConfiguration<TesteImagem>
    {
        public TesteImagemMap()
        {
            ToTable("TesteImagem");

            HasKey(k => k.Id);

            Property(p => p.Imagem).IsRequired();
        }
    }
}
