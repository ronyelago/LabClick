namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nomenclaturas2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Endereco", newName: "Enderecos");
            RenameTable(name: "dbo.Laboratorio", newName: "Laboratorios");
            AlterColumn("dbo.Laboratorios", "Nome", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Laboratorios", "Email", c => c.String(maxLength: 60, unicode: false));
            AlterColumn("dbo.Laboratorios", "DataCadastro", c => c.DateTime());
            AlterColumn("dbo.Laboratorios", "DataModificado", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Laboratorios", "DataModificado", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Laboratorios", "DataCadastro", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Laboratorios", "Email", c => c.String(maxLength: 1000, unicode: false));
            AlterColumn("dbo.Laboratorios", "Nome", c => c.String(maxLength: 1000, unicode: false));
            RenameTable(name: "dbo.Laboratorios", newName: "Laboratorio");
            RenameTable(name: "dbo.Enderecos", newName: "Endereco");
        }
    }
}
