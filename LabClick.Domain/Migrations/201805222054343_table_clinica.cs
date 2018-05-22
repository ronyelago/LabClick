namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table_clinica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clinicas", "Logotipo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clinicas", "Logotipo");
        }
    }
}
