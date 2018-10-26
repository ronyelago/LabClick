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
            var pacientes = (from user in Db.UsuarioLaboratorio
                             join lab in Db.Laboratorio on user.LaboratorioId equals lab.Id
                             join clinica in Db.Clinica on lab.Id equals clinica.LaboratorioId
                             join pac in Db.Paciente on clinica.Id equals pac.ClinicaId
                             where user.Id == id && pac.Testes.All(t => t.Status == "Em análise")
                             select pac)
                             .ToList();

            return pacientes;
        }

        public List<Paciente> GetByClinicaId(int clinicaId)
        {
            var listaPacientes = (from pacientes in Db.Paciente
                                  where pacientes.ClinicaId == clinicaId
                                  select pacientes)
                                  .Include(p => p.Testes)
                                  .ToList();

            return listaPacientes;
        }

        public List<Paciente> GetByName(string name)
        {
            var pacientes = Db.Paciente.Where(p => p.Nome.Contains(name))
                .Include(p => p.Endereco)
                .ToList();

            return pacientes;
        }

        public List<Paciente> GetByNameAndClinicaId(string name, int clinicaId)
        {
            var pacientesLista = (from pacientes in Db.Paciente
                                  where pacientes.ClinicaId == clinicaId
                                  && pacientes.Nome.Contains(name)
                                  select pacientes)
                                  .Include(p => p.Endereco)
                                  .ToList();

            return pacientesLista;
        }

        public Paciente GetByIdWithAddress(int id)
        {
            Paciente paciente = Db.Paciente.Include(p => p.Endereco)
                        .FirstOrDefault(pac => pac.Id == id);

            return paciente;
        }
    }
}