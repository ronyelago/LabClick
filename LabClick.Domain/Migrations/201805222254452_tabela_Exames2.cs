namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabela_Exames2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Exames", new[] { "Clinica_Id" });
            RenameColumn(table: "dbo.Exames", name: "Clinica_Id", newName: "ClinicaId");
            AlterColumn("dbo.Exames", "ClinicaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exames", "ClinicaId");
            DropColumn("dbo.Exames", "IdClinica");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exames", "IdClinica", c => c.Int(nullable: false));
            DropIndex("dbo.Exames", new[] { "ClinicaId" });
            AlterColumn("dbo.Exames", "ClinicaId", c => c.Int());
            RenameColumn(table: "dbo.Exames", name: "ClinicaId", newName: "Clinica_Id");
            CreateIndex("dbo.Exames", "Clinica_Id");
        }
    }
}
