namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbExame : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exames", "DataCadastro", c => c.DateTime());
            AlterColumn("dbo.Exames", "DataModificado", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exames", "DataModificado", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Exames", "DataCadastro", c => c.DateTime(nullable: false));
        }
    }
}
