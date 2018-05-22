namespace LabClick.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeira : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaboratorioId = c.Int(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 1000, unicode: false),
                        CNPJ = c.String(nullable: false, maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Logotipo = c.String(maxLength: 1000, unicode: false),
                        Data_inserido = c.DateTime(),
                        Data_modificado = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .ForeignKey("dbo.Laboratorio", t => t.LaboratorioId)
                .Index(t => t.LaboratorioId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cep = c.String(maxLength: 1000, unicode: false),
                        Cidade = c.String(maxLength: 1000, unicode: false),
                        UF = c.String(maxLength: 1000, unicode: false),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(maxLength: 1000, unicode: false),
                        Logradouro = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Laboratorio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnderecoId = c.Int(nullable: false),
                        Nome = c.String(maxLength: 1000, unicode: false),
                        Email = c.String(maxLength: 1000, unicode: false),
                        Assinatura = c.Binary(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataModificado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.EnderecoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clinica", "LaboratorioId", "dbo.Laboratorio");
            DropForeignKey("dbo.Laboratorio", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Clinica", "EnderecoId", "dbo.Endereco");
            DropIndex("dbo.Laboratorio", new[] { "EnderecoId" });
            DropIndex("dbo.Clinica", new[] { "EnderecoId" });
            DropIndex("dbo.Clinica", new[] { "LaboratorioId" });
            DropTable("dbo.Laboratorio");
            DropTable("dbo.Endereco");
            DropTable("dbo.Clinica");
        }
    }
}
