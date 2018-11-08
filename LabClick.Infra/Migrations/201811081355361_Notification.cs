namespace LabClick.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Testes", "VistoClinica", c => c.Boolean());
            AddColumn("dbo.Testes", "VistoLab", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Testes", "VistoLab");
            DropColumn("dbo.Testes", "VistoClinica");
        }
    }
}
