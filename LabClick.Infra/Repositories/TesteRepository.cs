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
                    .Include(t => t.Clinica)
                    .Include(t => t.Paciente)
                    .ToList();

            return testes;
        }

        /// <summary>
        /// Obtem  e retorna todos os testes dos pacientes pelo nome ou trecho do nome.
        /// Inclui as propriedades de navegação Paciente, Exame e Laudo.
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
                          .Include(t => t.Laudo)
                          .ToList();

            return testes;
        }

        /// <summary>
        /// Obtem pelo Id de um usuário [de um laboratório] todos os testes
        /// pelo qual o laboratório é responsável. Inclui as propriedades
        /// de navegação Clinica, Paciente, Exame. Ordena o retorno pela
        /// Data de Cadastro do Teste.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICollection<Teste> GetAllByUserLabId(int userId)
        {
            var testList = (from testes in Db.Teste
                            join clinica in Db.Clinica on testes.ClinicaId equals clinica.Id
                            join lab in Db.Laboratorio on clinica.LaboratorioId equals lab.Id
                            where lab.Id == userId
                            select testes)
                            .Include(t => t.Clinica)
                            .Include(t => t.Exame)
                            .Include(t => t.Paciente)
                            .ToList();

            return testList;
        }

        /// <summary>
        /// Obtem pelo Id de uma clínica todos os respectiovos testes.
        /// Inclui as propriedades de navegação Exame, Paciente, Clínica.
        /// </summary>
        /// <param name="clinicaId"></param>
        /// <returns></returns>
        public ICollection<Teste> GetAllByUserClinicaId(int clinicaId)
        {
            var testeList = (from testes in Db.Teste
                             where testes.ClinicaId == clinicaId
                             select testes)
                             .Include(t => t.Exame)
                             .Include(t => t.Paciente)
                             .Include(t => t.Clinica)
                             .ToList();

            return testeList;
        }

        /// <summary>
        /// Obtem pelo Id e retorna um único teste.
        /// Inclui as propriedades de navegação Paciente
        /// Paciente.Endereco, Clinica, Exame e Laudo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
