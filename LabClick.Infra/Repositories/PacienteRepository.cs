using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LabClick.Infra.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {
        public List<Paciente> GetByLabId(int id)
        {
            var pacientes = (from user in Db.Usuario
                             join lab in Db.Laboratorio on user.LaboratorioId equals lab.Id
                             join clinica in Db.Clinica on lab.Id equals clinica.LaboratorioId
                             join pac in Db.Paciente on clinica.Id equals pac.ClinicaId
                             where user.Id == id && pac.Testes.All(t => t.Status == "Em análise")
                             select pac).
                             ToList();

            return pacientes;
        }

        public List<Paciente> GetByName(string name)
        {
            var pacientes = Db.Paciente.Where(p => p.Nome.Contains(name)).
                Include(p => p.Endereco).
                ToList();

            return pacientes;
        }
    }
}