namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabela_Usuarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaboratorioId = c.Int(nullable: false),
                        ClinicaId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Senha = c.String(maxLength: 1000, unicode: false),
                        Perfil = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinicas", t => t.ClinicaId)
                .ForeignKey("dbo.Laboratorios", t => t.LaboratorioId)
                .Index(t => t.LaboratorioId)
                .Index(t => t.ClinicaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "LaboratorioId", "dbo.Laboratorios");
            DropForeignKey("dbo.Usuarios", "ClinicaId", "dbo.Clinicas");
            DropIndex("dbo.Usuarios", new[] { "ClinicaId" });
            DropIndex("dbo.Usuarios", new[] { "LaboratorioId" });
            DropTable("dbo.Usuarios");
        }
    }
}
