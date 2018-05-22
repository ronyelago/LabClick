using System;

namespace LabClick.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int LaboratorioId { get; set; }
        public int ClinicaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataModificado { get; set; }
        public virtual Laboratorio Laboratorio { get; set; }
        public virtual Clinica Clinica { get; set; }
    }
}
