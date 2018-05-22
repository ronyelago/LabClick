namespace LabClick.Domain.Migrations
{
    using LabClick.Domain.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LabClickContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LabClickContext context)
        {
            Endereco endereco = new Endereco
            {
                Cep = "04192-289",
                Cidade = "São Paulo",
                UF = "SP",
                Numero = 123,
                Bairro = "Jardim Alipio",
                Logradouro = "Rua Carabinani"
            };

            context.Endereco.Add(endereco);
            context.SaveChanges();
        }
    }
}