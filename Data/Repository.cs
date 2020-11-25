using System.Linq;
using smartschool.Models;
using Microsoft.EntityFrameworkCore;

namespace smartschool.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext database;
        public Repository(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void Add<T>(T entity) where T : class
        {
            database.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            database.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            database.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (database.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = database.alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(a => a.Disciplina).ThenInclude(a => a.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = database.alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(a => a.Disciplina).ThenInclude(a => a.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.AlunosDisciplinas.Any(a => a.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = database.alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(a => a.Disciplina).ThenInclude(a => a.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = database.professores;

            if(includeAlunos)
            {
                query = query.Include(p => p.Disciplinas).ThenInclude(p => p.AlunosDisciplinas).ThenInclude(p => p.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = database.professores;

            if(includeAlunos)
            {
                query = query.Include(p => p.Disciplinas).ThenInclude(p => p.AlunosDisciplinas).ThenInclude(p => p.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Disciplinas.Any(p => p.AlunosDisciplinas.Any(p => p.DisciplinaId == disciplinaId)));

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeProfessor = false)
        {
            IQueryable<Professor> query = database.professores;

            if (includeProfessor)
            {
                query = query.Include(p => p.Disciplinas).ThenInclude(p => p.AlunosDisciplinas).ThenInclude(p => p.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == professorId);

            return query.FirstOrDefault();
        }
    }
}