namespace LabClick.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetalhesResultado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Laudos", "ResultadoDetalhes", c => c.String(maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Laudos", "ResultadoDetalhes");
        }
    }
}
