namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class End_IsOptional : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clinicas", new[] { "EnderecoId" });
            AlterColumn("dbo.Clinicas", "EnderecoId", c => c.Int());
            CreateIndex("dbo.Clinicas", "EnderecoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clinicas", new[] { "EnderecoId" });
            AlterColumn("dbo.Clinicas", "EnderecoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clinicas", "EnderecoId");
        }
    }
}
