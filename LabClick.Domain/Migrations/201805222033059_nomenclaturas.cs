namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nomenclaturas : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Clinica", newName: "Clinicas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Clinicas", newName: "Clinica");
        }
    }
}
