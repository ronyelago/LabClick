using LabClick.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LabClick.ViewModel
{
    public class PacienteViewModel
    {
        public string SearchName { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}