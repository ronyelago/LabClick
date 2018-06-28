using LabClick.Domain.Entities;
using LabClick.Infra.Data;
using System;
using System.Data.Entity.Migrations;

namespace LabClick.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LabClickContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LabClickContext context)
        {
            Endereco endereco1 = new Endereco
            {
                Cep = "05192-289",
                Cidade = "São Paulo",
                UF = "SP",
                Numero = 123,
                Bairro = "Jardim Marizal",
                Logradouro = "Rua Carabinani"
            };

            Endereco endereco2 = new Endereco
            {
                Cep = "04192-289",
                Cidade = "São Paulo",
                UF = "SP",
                Numero = 788,
                Bairro = "Vila Madalena",
                Logradouro = "Rua Jabaculemos"
            };

            Endereco endereco3 = new Endereco
            {
                Cep = "07192-289",
                Cidade = "São Paulo",
                UF = "SP",
                Numero = 1544,
                Bairro = "Butantan",
                Logradouro = "Rua Três Irmãos"
            };

            Endereco endereco4 = new Endereco
            {
                Cep = "09992-289",
                Cidade = "Taboão da Serra",
                UF = "SP",
                Numero = 876,
                Bairro = "Parque Laguna",
                Logradouro = "Rua Tom Jobim"
            };

            Endereco endereco5 = new Endereco
            {
                Cep = "02192-654",
                Cidade = "São Paulo",
                UF = "SP",
                Numero = 543,
                Bairro = "Caxingui",
                Logradouro = "Rua Joabe"
            };

            Endereco endereco6 = new Endereco
            {
                Cep = "56765-289",
                Cidade = "São Paulo",
                UF = "SP",
                Numero = 423,
                Bairro = "Jardim Guedala",
                Logradouro = "Rua Fausto Silva"
            };

            Endereco endereco7 = new Endereco
            {
                Cep = "05492-289",
                Cidade = "São Paulo",
                UF = "SP",
                Numero = 988,
                Bairro = "Parque Bristol",
                Logradouro = "Rua Silvio Santos"
            };

            Endereco endereco8 = new Endereco
            {
                Cep = "08976-289",
                Cidade = "São Paulo",
                UF = "SP",
                Numero = 566,
                Bairro = "Limão",
                Logradouro = "Rua Nadilson Alves"
            };

            context.Endereco.Add(endereco1);
            context.Endereco.Add(endereco2);
            context.Endereco.Add(endereco3);
            context.Endereco.Add(endereco4);
            context.Endereco.Add(endereco5);
            context.Endereco.Add(endereco6);
            context.Endereco.Add(endereco7);
            context.Endereco.Add(endereco8);
            context.SaveChanges();

            Laboratorio lab1 = new Laboratorio
            {
                EnderecoId = 1,
                Nome = "Laboratório 1",
                Email = "lab1@email.com.br",
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            Laboratorio lab2 = new Laboratorio
            {
                EnderecoId = 2,
                Nome = "Laboratório 2",
                Email = "lab2@email.com.br",
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            context.Laboratorio.Add(lab1);
            context.Laboratorio.Add(lab2);
            context.SaveChanges();

            Clinica clinica1 = new Clinica
            {
                LaboratorioId = 1,
                EnderecoId = 3,
                Nome = "Clínica 1",
                CNPJ = "18.080.506/5315-19",
                Email = "clinica1@email.com.br",
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            Clinica clinica2 = new Clinica
            {
                LaboratorioId = 2,
                EnderecoId = 4,
                Nome = "Clínica 2",
                CNPJ = "19.619.185/0850-35",
                Email = "clinica2@email.com.br",
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            context.Clinica.Add(clinica1);
            context.Clinica.Add(clinica2);
            context.SaveChanges();

            Usuario u1 = new Usuario
            {
                LaboratorioId = 1,
                ClinicaId = 1,
                Nome = "Ronye do Lago",
                Email = "ronye.rocha@gmail.com",
                Senha = "759310",
                Perfil = "Administrador",
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            Usuario u2 = new Usuario
            {
                LaboratorioId = 2,
                ClinicaId = 2,
                Nome = "Olis do Lago",
                Email = "olis@gmail.com",
                Senha = "759310",
                Perfil = "Administrador",
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            context.Usuario.Add(u1);
            context.Usuario.Add(u2);
            context.SaveChanges();

            Paciente p1 = new Paciente
            {
                ClinicaId = 1,
                EnderecoId = 5,
                Nome = "Jovelino Jovial Jubilane",
                Sexo = "Masculino",
                Email = "jovelino@email.com.br",
                Telefone = "(11) 93456-4523",
                Cpf = "543.987.364-50",
                DataNascimento = new DateTime(1980, 3, 20),
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            Paciente p2 = new Paciente
            {
                ClinicaId = 1,
                EnderecoId = 6,
                Nome = "Juventina Jovial Jubilane",
                Sexo = "Feminino",
                Email = "jovelina@email.com.br",
                Telefone = "(11) 93456-4523",
                Cpf = "987.987.364-50",
                DataNascimento = new DateTime(1970, 10, 11),
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            Paciente p3 = new Paciente
            {
                ClinicaId = 2,
                EnderecoId = 7,
                Nome = "Marcondes Herculano",
                Sexo = "Masculino",
                Email = "marcondes@email.com.br",
                Telefone = "(11) 93456-4523",
                Cpf = "445.987.364-50",
                DataNascimento = new DateTime(1986, 4, 7),
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            Paciente p4 = new Paciente
            {
                ClinicaId = 2,
                EnderecoId = 8,
                Nome = "Fábio da Silva Júnior",
                Sexo = "Masculino",
                Email = "fabiojr@email.com.br",
                Telefone = "(11) 94567-4523",
                Cpf = "788.987.364-50",
                DataNascimento = new DateTime(1960, 12, 9),
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            context.Paciente.Add(p1);
            context.Paciente.Add(p2);
            context.Paciente.Add(p3);
            context.Paciente.Add(p4);
            context.SaveChanges();

            Exame exame1 = new Exame
            {
                Nome = "Zika",
                ClinicaId = 1,
                Descricao = "Exame de Zika",
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            Exame exame2 = new Exame
            {
                Nome = "Zika",
                ClinicaId = 2,
                Descricao = "Exame de Zika",
                DataCadastro = DateTime.Now,
                DataModificado = DateTime.Now
            };

            context.Exame.Add(exame1);
            context.Exame.Add(exame2);
            context.SaveChanges();

            Teste t1 = new Teste
            {
                ExameId = 1,
                ClinicaId = 1,
                PacienteId = 1,
                Imagem = null,
                Status = "Aguardando análise",
                DataCadastro = DateTime.Now
            };

            Teste t2 = new Teste
            {
                ExameId = 1,
                ClinicaId = 1,
                PacienteId = 2,
                Imagem = null,
                Status = "Aguardando análise",
                DataCadastro = DateTime.Now
            };

            Teste t3 = new Teste
            {
                ExameId = 2,
                ClinicaId = 2,
                PacienteId = 3,
                Imagem = null,
                Status = "Aguardando análise",
                DataCadastro = DateTime.Now
            };

            Teste t4 = new Teste
            {
                ExameId = 2,
                ClinicaId = 2,
                PacienteId = 4,
                Imagem = null,
                Status = "Aguardando análise",
                DataCadastro = DateTime.Now
            };

            context.Teste.Add(t1);
            context.Teste.Add(t2);
            context.Teste.Add(t3);
            context.Teste.Add(t4);
            context.SaveChanges();

            //Laudo r1 = new Laudo
            //{
            //    Id = 1,
            //    Resultado = "",
            //    Observacoes = "Nenhuma",
            //    Documento = null,
            //    DataCadastro = DateTime.Now
            //};

            //Laudo r2 = new Laudo
            //{
            //    Id = 2,
            //    Resultado = "",
            //    Observacoes = "Nenhuma",
            //    Documento = null,
            //    DataCadastro = DateTime.Now
            //};

            //Laudo r3 = new Laudo
            //{
            //    Id = 3,
            //    Resultado = "",
            //    Observacoes = "Nenhuma",
            //    Documento = null,
            //    DataCadastro = DateTime.Now
            //};

            //Laudo r4 = new Laudo
            //{
            //    Id = 4,
            //    Resultado = "",
            //    Observacoes = "Nenhuma",
            //    Documento = null,
            //    DataCadastro = DateTime.Now
            //};

            //context.Laudo.Add(r1);
            //context.Laudo.Add(r2);
            //context.Laudo.Add(r3);
            //context.Laudo.Add(r4);
            //context.SaveChanges();
        }
    }
}