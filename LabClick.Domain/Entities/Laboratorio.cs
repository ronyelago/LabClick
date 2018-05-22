using System;
using System.Collections.Generic;

namespace LabClick.Domain.Entities
{
    public class Laboratorio
    {
        public int Id { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] Assinatura { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataModificado { get; set; }
        public virtual Endereco Endereco { get; set; }
        public IEnumerable<Clinica> Clinicas { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
