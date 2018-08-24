namespace LabClick.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enderecos", "Cep", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Enderecos", "Cidade", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Enderecos", "UF", c => c.String(maxLength: 6, unicode: false));
            AlterColumn("dbo.Enderecos", "Bairro", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Enderecos", "Logradouro", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enderecos", "Logradouro", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Enderecos", "Bairro", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Enderecos", "UF", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Enderecos", "Cidade", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Enderecos", "Cep", c => c.String(maxLength: 500, unicode: false));
        }
    }
}
