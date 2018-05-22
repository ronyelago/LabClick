namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabela_teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Testes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExameId = c.Int(nullable: false),
                        ClinicaId = c.Int(nullable: false),
                        PacienteId = c.Int(nullable: false),
                        Imgem = c.Binary(),
                        Status = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinicas", t => t.ClinicaId)
                .ForeignKey("dbo.Exames", t => t.ExameId)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId)
                .Index(t => t.ExameId)
                .Index(t => t.ClinicaId)
                .Index(t => t.PacienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Testes", "PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Testes", "ExameId", "dbo.Exames");
            DropForeignKey("dbo.Testes", "ClinicaId", "dbo.Clinicas");
            DropIndex("dbo.Testes", new[] { "PacienteId" });
            DropIndex("dbo.Testes", new[] { "ClinicaId" });
            DropIndex("dbo.Testes", new[] { "ExameId" });
            DropTable("dbo.Testes");
        }
    }
}
