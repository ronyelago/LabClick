namespace LabClick.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaboratorioId = c.Int(),
                        EnderecoId = c.Int(),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        CNPJ = c.String(nullable: false, maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Logotipo = c.Binary(),
                        DataCadastro = c.DateTime(),
                        DataModificado = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId)
                .ForeignKey("dbo.Laboratorios", t => t.LaboratorioId)
                .Index(t => t.LaboratorioId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cep = c.String(maxLength: 500, unicode: false),
                        Cidade = c.String(maxLength: 500, unicode: false),
                        UF = c.String(maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(maxLength: 500, unicode: false),
                        Logradouro = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Laboratorios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnderecoId = c.Int(),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 60, unicode: false),
                        Assinatura = c.Binary(),
                        DataCadastro = c.DateTime(),
                        DataModificado = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Exames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        ClinicaId = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 700, unicode: false),
                        DataCadastro = c.DateTime(),
                        DataModificado = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinicas", t => t.ClinicaId)
                .Index(t => t.ClinicaId);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicaId = c.Int(nullable: false),
                        EnderecoId = c.Int(),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Sexo = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 30, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 20, unicode: false),
                        DataNascimento = c.DateTime(precision: 7, storeType: "datetime2"),
                        DataCadastro = c.DateTime(),
                        DataModificado = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinicas", t => t.ClinicaId)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId)
                .Index(t => t.ClinicaId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Resultados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExameId = c.Int(nullable: false),
                        TesteId = c.Int(nullable: false),
                        Laudo = c.Binary(),
                        Tabela = c.String(maxLength: 500, unicode: false),
                        Observacoes = c.String(maxLength: 200, unicode: false),
                        Documento = c.Binary(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exames", t => t.ExameId)
                .ForeignKey("dbo.Testes", t => t.TesteId)
                .Index(t => t.ExameId)
                .Index(t => t.TesteId);
            
            CreateTable(
                "dbo.Testes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExameId = c.Int(nullable: false),
                        ClinicaId = c.Int(nullable: false),
                        PacienteId = c.Int(nullable: false),
                        Imagem = c.Binary(),
                        Status = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCadastro = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinicas", t => t.ClinicaId)
                .ForeignKey("dbo.Exames", t => t.ExameId)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId)
                .Index(t => t.ExameId)
                .Index(t => t.ClinicaId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaboratorioId = c.Int(nullable: false),
                        ClinicaId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Senha = c.String(maxLength: 500, unicode: false),
                        Perfil = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCadastro = c.DateTime(),
                        DataModificado = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinicas", t => t.ClinicaId)
                .ForeignKey("dbo.Laboratorios", t => t.LaboratorioId)
                .Index(t => t.LaboratorioId)
                .Index(t => t.ClinicaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "LaboratorioId", "dbo.Laboratorios");
            DropForeignKey("dbo.Usuarios", "ClinicaId", "dbo.Clinicas");
            DropForeignKey("dbo.Resultados", "TesteId", "dbo.Testes");
            DropForeignKey("dbo.Testes", "PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Testes", "ExameId", "dbo.Exames");
            DropForeignKey("dbo.Testes", "ClinicaId", "dbo.Clinicas");
            DropForeignKey("dbo.Resultados", "ExameId", "dbo.Exames");
            DropForeignKey("dbo.Pacientes", "EnderecoId", "dbo.Enderecos");
            DropForeignKey("dbo.Pacientes", "ClinicaId", "dbo.Clinicas");
            DropForeignKey("dbo.Exames", "ClinicaId", "dbo.Clinicas");
            DropForeignKey("dbo.Clinicas", "LaboratorioId", "dbo.Laboratorios");
            DropForeignKey("dbo.Laboratorios", "EnderecoId", "dbo.Enderecos");
            DropForeignKey("dbo.Clinicas", "EnderecoId", "dbo.Enderecos");
            DropIndex("dbo.Usuarios", new[] { "ClinicaId" });
            DropIndex("dbo.Usuarios", new[] { "LaboratorioId" });
            DropIndex("dbo.Testes", new[] { "PacienteId" });
            DropIndex("dbo.Testes", new[] { "ClinicaId" });
            DropIndex("dbo.Testes", new[] { "ExameId" });
            DropIndex("dbo.Resultados", new[] { "TesteId" });
            DropIndex("dbo.Resultados", new[] { "ExameId" });
            DropIndex("dbo.Pacientes", new[] { "EnderecoId" });
            DropIndex("dbo.Pacientes", new[] { "ClinicaId" });
            DropIndex("dbo.Exames", new[] { "ClinicaId" });
            DropIndex("dbo.Laboratorios", new[] { "EnderecoId" });
            DropIndex("dbo.Clinicas", new[] { "EnderecoId" });
            DropIndex("dbo.Clinicas", new[] { "LaboratorioId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Testes");
            DropTable("dbo.Resultados");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Exames");
            DropTable("dbo.Laboratorios");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Clinicas");
        }
    }
}
