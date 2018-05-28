using LabClick.Domain.Entities;
using LabClick.Domain.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LabClick.Domain
{
    public class LabClickContext : DbContext
    {
        public LabClickContext() : base("Name=LabClickContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Laboratorio> Laboratorio { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Exame> Exame { get; set; }
        public DbSet<Teste> Teste { get; set; }
        public DbSet<Resultado> Resultado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClinicaMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new LaboratorioMap());
            modelBuilder.Configurations.Add(new PacienteMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new ExameMap());
            modelBuilder.Configurations.Add(new TesteMap());
            modelBuilder.Configurations.Add(new ResultadoMap());

            //Remove a pluralização automática das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Remove a exclusão em cascata de tabelas relacionadas (um para muitos)
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Remove a exclusão em cascata de tableas relacionadas (muitos para muitos)
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Diz ao EF que todos nomes de campos que forem Id serão PK
            modelBuilder.Properties().
                Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Diz ao EF que todos os campos tipo string serão varchar com tamanho máximo de 1000
            modelBuilder.Properties<string>().
                Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().
                Configure(p => p.HasMaxLength(500));
        }
    }
}
