using System;
using System.Collections.Generic;

namespace LabClick.Domain.Entities
{
    public class Clinica
    {
        public int Id { get; set; }
        public int LaboratorioId { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public byte[] Logotipo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataModificado { get; set; }
        public virtual Laboratorio Laboratorio { get; set; }
        public virtual Endereco Endereco { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set;}
        public IEnumerable<Paciente> Pacientes { get; set; }
    }
}
