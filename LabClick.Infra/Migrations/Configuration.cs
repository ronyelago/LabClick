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
            //ok
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

            //ok
            //Laboratorio lab = new Laboratorio
            //{
            //    EnderecoId = 1,
            //    Nome = "Laboratório 1",
            //    Email = "lab1@email.com.br",
            //    DataCadastro = DateTime.Now,
            //    DataModificado = DateTime.Now
            //};

            //context.Laboratorio.Add(lab);
            //context.SaveChanges();

            ////ok
            //Clinica clinica1 = new Clinica
            //{
            //    LaboratorioId = 1,
            //    EnderecoId = 1,
            //    Nome = "Clínica 1",
            //    CNPJ = "18.080.506/5315-19",
            //    Email = "clinica1@email.com.br",
            //    DataCadastro = DateTime.Now,
            //    DataModificado = DateTime.Now
            //};

            ////ok
            //Clinica clinica2 = new Clinica
            //{
            //    LaboratorioId = 1,
            //    EnderecoId = 1,
            //    Nome = "Clínica 2",
            //    CNPJ = "19.619.185/0850-35",
            //    Email = "clinica2@email.com.br",
            //    DataCadastro = DateTime.Now,
            //    DataModificado = DateTime.Now
            //};

            //context.Clinica.Add(clinica1);
            //context.Clinica.Add(clinica2);
            //context.SaveChanges();

            ////ok
            //Paciente p1 = new Paciente
            //{
            //    ClinicaId = 1,
            //    EnderecoId = 1,
            //    Nome = "Jovelino Jovial Jubilane",
            //    Sexo = "Masculino",
            //    Email = "jovelino@email.com.br",
            //    Telefone = "(11) 93456-4523",
            //    Cpf = "378.987.364-50",
            //    DataNascimento = DateTime.Now,
            //    DataCadastro = DateTime.Now,
            //    DataModificado = DateTime.Now
            //};

            ////ok
            //Paciente p2 = new Paciente
            //{
            //    ClinicaId = 2,
            //    EnderecoId = 1,
            //    Nome = "Juventina Jovial Jubilane",
            //    Sexo = "Feminino",
            //    Email = "jovelina@email.com.br",
            //    Telefone = "(11) 93456-4523",
            //    Cpf = "378.987.364-50",
            //    DataNascimento = DateTime.Now,
            //    DataCadastro = DateTime.Now,
            //    DataModificado = DateTime.Now
            //};

            //context.Paciente.Add(p1);
            //context.Paciente.Add(p2);
            //context.SaveChanges();

            ////ok
            //Exame exame1 = new Exame
            //{
            //    Nome = "Glicose",
            //    ClinicaId = 1,
            //    Descricao = "O exame de glicose, também conhecido como teste da glicose, é feito com objetivo de verificar a quantidade de açúcar no sangue, sendo o principal exame realizado para diagnosticar a diabetes.",
            //    DataCadastro = DateTime.Now,
            //    DataModificado = DateTime.Now
            //};

            ////ok
            //Exame exame2 = new Exame
            //{
            //    Nome = "Urina",
            //    ClinicaId = 1,
            //    Descricao = "O exame de urina serve para diagnosticar problemas que afetam o sistema renal e urinário, existindo três tipos principais: o exame de urina tipo 1, o exame de urina de 24 horas e o exame de urocultura, que geralmente são realizados num laboratório de análises clínicas e nenhum deles necessita de jejum.",
            //    DataCadastro = DateTime.Now,
            //    DataModificado = DateTime.Now
            //};

            //Exame Exame3 = new Exame
            //{
            //    Nome = "Zika",
            //    ClinicaId = 2,
            //    Descricao = "Exame de Zika",
            //    DataCadastro = DateTime.Now,
            //    DataModificado = DateTime.Now
            //};

            //context.Exame.Add(exame1);
            //context.Exame.Add(exame2);
            //context.SaveChanges();

            //Teste t1 = new Teste
            //{
            //    ExameId = 1,
            //    ClinicaId = 1,
            //    PacienteId = 1,
            //    Imagem = null,
            //    Status = "Finalizado",
            //    DataCadastro = DateTime.Now
            //};

            //Teste t2 = new Teste
            //{
            //    ExameId = 2,
            //    ClinicaId = 1,
            //    PacienteId = 2,
            //    Imagem = null,
            //    Status = "Finalizado",
            //    DataCadastro = DateTime.Now
            //};

            //context.Teste.Add(t1);
            //context.Teste.Add(t2);
            //context.SaveChanges();
        }
    }
}