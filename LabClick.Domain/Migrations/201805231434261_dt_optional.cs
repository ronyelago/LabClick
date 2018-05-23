namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dt_optional : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clinicas", "DataCadastro", c => c.DateTime());
            AddColumn("dbo.Clinicas", "DataModificado", c => c.DateTime());
            AlterColumn("dbo.Pacientes", "DataNascimento", c => c.DateTime());
            AlterColumn("dbo.Pacientes", "DataCadastro", c => c.DateTime());
            AlterColumn("dbo.Pacientes", "DataModificado", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "DataCadastro", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "DataModificado", c => c.DateTime());
            DropColumn("dbo.Clinicas", "Data_inserido");
            DropColumn("dbo.Clinicas", "Data_modificado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clinicas", "Data_modificado", c => c.DateTime());
            AddColumn("dbo.Clinicas", "Data_inserido", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "DataModificado", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "DataCadastro", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pacientes", "DataModificado", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pacientes", "DataCadastro", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pacientes", "DataNascimento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Clinicas", "DataModificado");
            DropColumn("dbo.Clinicas", "DataCadastro");
        }
    }
}
