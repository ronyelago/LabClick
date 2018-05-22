namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table_paciente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicaId = c.Int(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Sexo = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 30, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 20, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinicas", t => t.ClinicaId)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId)
                .Index(t => t.ClinicaId)
                .Index(t => t.EnderecoId);
            
            AlterColumn("dbo.Clinicas", "Nome", c => c.String(nullable: false, maxLength: 150, unicode: false));
            DropColumn("dbo.Clinicas", "Logotipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clinicas", "Logotipo", c => c.String(maxLength: 1000, unicode: false));
            DropForeignKey("dbo.Pacientes", "EnderecoId", "dbo.Enderecos");
            DropForeignKey("dbo.Pacientes", "ClinicaId", "dbo.Clinicas");
            DropIndex("dbo.Pacientes", new[] { "EnderecoId" });
            DropIndex("dbo.Pacientes", new[] { "ClinicaId" });
            AlterColumn("dbo.Clinicas", "Nome", c => c.String(nullable: false, maxLength: 1000, unicode: false));
            DropTable("dbo.Pacientes");
        }
    }
}
