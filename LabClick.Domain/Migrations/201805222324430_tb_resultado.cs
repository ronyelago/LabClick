namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tb_resultado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resultados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExameId = c.Int(nullable: false),
                        TesteId = c.Int(nullable: false),
                        Laudo = c.Binary(),
                        Tabela = c.String(maxLength: 500, unicode: false),
                        Observacoes = c.String(maxLength: 200, unicode: false),
                        Documento = c.Binary(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exames", t => t.ExameId)
                .ForeignKey("dbo.Testes", t => t.TesteId)
                .Index(t => t.ExameId)
                .Index(t => t.TesteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resultados", "TesteId", "dbo.Testes");
            DropForeignKey("dbo.Resultados", "ExameId", "dbo.Exames");
            DropIndex("dbo.Resultados", new[] { "TesteId" });
            DropIndex("dbo.Resultados", new[] { "ExameId" });
            DropTable("dbo.Resultados");
        }
    }
}
