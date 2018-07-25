using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;

namespace LabClick.Infra.Repositories
{
    public class TesteRepository : RepositoryBase<Teste>, ITesteRepository
    {
        public ICollection<Teste> GetAllByPacienteId(int pacienteId)
        {
            var testes = Db.Teste.Where(t => t.PacienteId == pacienteId)
                    .Include(t => t.Exame)
                    .ToList();

            return testes;
        }

        public ICollection<Teste> GetAllByUserId(int userId)
        {
            var testes = (from user in Db.Usuario
                          join lab in Db.Laboratorio on user.LaboratorioId equals lab.Id
                          join clinica in Db.Clinica on lab.Id equals clinica.LaboratorioId
                          join teste in Db.Teste on clinica.Id equals teste.ClinicaId
                          where user.Id == userId
                          select teste)
                          .Include(t => t.Clinica)
                          .Include(t => t.Paciente)
                          .Include(t => t.Exame)
                          .Include(t => t.Laudo)
                          .OrderBy(t => t.DataCadastro)
                          .ToList();

            return testes;
        }

        public override Teste GetById(int id)
        {
            Teste teste = Db.Teste
                .Include(t => t.Paciente)
                .Include(t => t.Paciente.Endereco)
                .Include(t => t.Clinica)
                .Include(t => t.Exame)
                .Include(t => t.Laudo)
                .FirstOrDefault(t => t.Id == id);

            return teste;
        }

        public Teste GetByPatientId(int pacienteId)
        {
            Teste teste = Db.Teste
                .Include(t => t.Paciente)
                .Include(t => t.Paciente.Endereco)
                .Include(t => t.Clinica)
                .Include(t => t.Exame)
                .Include(t => t.Laudo)
                .FirstOrDefault(t => t.PacienteId == pacienteId);

            return teste;
        }
    }
}
