using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LabClick.Domain.Data.Interfaces;
using LabClick.Domain.Entities;

namespace LabClick.Infra.Repositories
{
    public class TesteRepository : RepositoryBase<Teste>, ITesteRepository
    {
        /// <summary>
        /// Obtem todos os testes de um paciente pelo seu respectivo Id
        /// e os retorna. Inclui as propriedades de navegação Exame e Laudo.
        /// </summary>
        /// <param name="pacienteId"></param>
        /// <returns></returns>
        public ICollection<Teste> GetAllByPacienteId(int pacienteId)
        {
            var testes = Db.Teste.Where(t => t.PacienteId == pacienteId)
                    .Include(t => t.Exame)
                    .Include(t => t.Laudo)
                    .ToList();

            return testes;
        }

        /// <summary>
        /// Obtem  e retorna todos os testes dos pacientes pelo nome ou trecho do nome.
        /// Inclui as propriedades de navegação Paciente e Exame.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ICollection<Teste> GetAllByPacienteName(string name)
        {
            var testes = (from test in Db.Teste
                          join pac in Db.Paciente on test.PacienteId equals pac.Id
                          where pac.Nome.Contains(name)
                          select test)
                          .Include(t => t.Paciente)
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
