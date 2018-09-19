namespace LabClick.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TesteImagem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Testes", "Id", "dbo.TesteImagem");
            DropIndex("dbo.Testes", new[] { "Id" });
            DropColumn("dbo.Testes", "TesteImagemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Testes", "TesteImagemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Testes", "Id");
            AddForeignKey("dbo.Testes", "Id", "dbo.TesteImagem", "Id");
        }
    }
}
