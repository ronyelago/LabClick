namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Testes", "Imagem", c => c.Binary());
            AlterColumn("dbo.Testes", "DataCadastro", c => c.DateTime());
            DropColumn("dbo.Testes", "Imgem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Testes", "Imgem", c => c.Binary());
            AlterColumn("dbo.Testes", "DataCadastro", c => c.DateTime(nullable: false));
            DropColumn("dbo.Testes", "Imagem");
        }
    }
}
