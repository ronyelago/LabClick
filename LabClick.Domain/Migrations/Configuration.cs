namespace LabClick.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LabClickContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LabClickContext context)
        {
            //Endereco endereco = new Endereco
            //{
            //    Cep = "04192-289",
            //    Cidade = "São Paulo",
            //    UF = "SP",
            //    Numero = 123,
            //    Bairro = "Jardim Alipio",
            //    Logradouro = "Rua Carabinani"
            //};

            //context.Endereco.Add(endereco);
            //context.SaveChanges();

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

            //Paciente p1 = new Paciente
            //{
            //    ClinicaId = 3,
            //    EnderecoId = 2,
            //    Nome = "Jovelino Jovial Jubilane",
            //    Sexo = "Masculino",
            //    Email = "jovelino@email.com.br",
            //    Telefone = "(11) 93456-4523",
            //    Cpf = "378.987.364-50",
            //    DataNascimento = DateTime.Now,
            //    DataCadastro = DateTime.Now,
            //    DataModificado = DateTime.Now
            //};

            //Paciente p2 = new Paciente
            //{
            //    ClinicaId = 3,
            //    EnderecoId = 2,
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
        }
    }
}