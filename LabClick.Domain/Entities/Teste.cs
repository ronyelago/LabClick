﻿using System;
using System.Collections.Generic;

namespace LabClick.Domain.Entities
{
    public class Teste
    {
        public int Id { get; set; }
        public int ExameId { get; set; }
        public int ClinicaId { get; set; }
        public int PacienteId { get; set; }
        public byte[] Imgem { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Exame Exame { get; set; }
        public virtual Clinica Clinica { get; set; }
        public virtual Paciente Paciente { get; set; }
        public IEnumerable<Resultado> Resultados { get; set; }
    }
}
