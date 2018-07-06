namespace LabClick.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Flag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Testes", "LaudoOk", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Testes", "LaudoOk");
        }
    }
}
