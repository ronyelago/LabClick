namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class End_optional : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clinicas", new[] { "LaboratorioId" });
            DropIndex("dbo.Laboratorios", new[] { "EnderecoId" });
            DropIndex("dbo.Pacientes", new[] { "EnderecoId" });
            AlterColumn("dbo.Clinicas", "LaboratorioId", c => c.Int());
            AlterColumn("dbo.Laboratorios", "EnderecoId", c => c.Int());
            AlterColumn("dbo.Pacientes", "EnderecoId", c => c.Int());
            CreateIndex("dbo.Clinicas", "LaboratorioId");
            CreateIndex("dbo.Laboratorios", "EnderecoId");
            CreateIndex("dbo.Pacientes", "EnderecoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pacientes", new[] { "EnderecoId" });
            DropIndex("dbo.Laboratorios", new[] { "EnderecoId" });
            DropIndex("dbo.Clinicas", new[] { "LaboratorioId" });
            AlterColumn("dbo.Pacientes", "EnderecoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Laboratorios", "EnderecoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clinicas", "LaboratorioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pacientes", "EnderecoId");
            CreateIndex("dbo.Laboratorios", "EnderecoId");
            CreateIndex("dbo.Clinicas", "LaboratorioId");
        }
    }
}
