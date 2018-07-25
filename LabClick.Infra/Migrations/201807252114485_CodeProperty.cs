namespace LabClick.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Testes", "Code", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Testes", "Code");
        }
    }
}
