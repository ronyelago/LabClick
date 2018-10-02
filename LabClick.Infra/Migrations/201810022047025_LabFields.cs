namespace LabClick.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LabFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Laboratorios", "ImagemLogo", c => c.Binary());
            AddColumn("dbo.Laboratorios", "ImagemFooter", c => c.Binary());
            DropColumn("dbo.Laboratorios", "Assinatura");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Laboratorios", "Assinatura", c => c.Binary());
            DropColumn("dbo.Laboratorios", "ImagemFooter");
            DropColumn("dbo.Laboratorios", "ImagemLogo");
        }
    }
}
