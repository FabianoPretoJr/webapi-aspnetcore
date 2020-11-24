using Microsoft.EntityFrameworkCore;
using smartschool.Models;

namespace smartschool.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Aluno> alunos { get; set; }
        public DbSet<Professor> professores { get; set; }
        public DbSet<Disciplina> disciplinas { get; set; }
        public DbSet<AlunoDisciplina> alunosDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>().HasKey(sc => new { sc.AlunoId, sc.DisciplinaId});
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
    }
}