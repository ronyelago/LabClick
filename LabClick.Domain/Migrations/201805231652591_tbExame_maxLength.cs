namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbExame_maxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exames", "Descricao", c => c.String(nullable: false, maxLength: 700, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exames", "Descricao", c => c.String(nullable: false, maxLength: 300, unicode: false));
        }
    }
}
