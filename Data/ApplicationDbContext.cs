using System.Collections.Generic;
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

            modelBuilder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, "Fabiano", "Preto", "12345678"),
                    new Aluno(2, "Gustavo", "Preto", "12345678"),
                    new Aluno(3, "Karine", "Martins", "12345678"),
                    new Aluno(4, "João", "Oliveira", "12345678"),
                    new Aluno(5, "Isabela", "Freitas", "12345678"),
                });

            modelBuilder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, "Alexandre"),
                    new Professor(2, "Vania"),
                    new Professor(3, "Carol"),
                    new Professor(4, "Aristides"),
                    new Professor(5, "Demervaldo"),
                });

            modelBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>(){
                    new Disciplina(1, "Educação Física", 1),
                    new Disciplina(2, "GSO", 3),
                    new Disciplina(3, "Engenharia de Software", 2),
                    new Disciplina(4, "Sistemas Operacionais I", 4),
                    new Disciplina(5, "Administração", 5),
                    new Disciplina(6, "Redes", 3),
                    new Disciplina(7, "Gerencia de Projetos", 5),
                    new Disciplina(8, "Eventos", 1),
                });

            modelBuilder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>(){
                    new AlunoDisciplina(1, 2),
                    new AlunoDisciplina(1, 6),
                    new AlunoDisciplina(2, 1),
                    new AlunoDisciplina(2, 8),
                    new AlunoDisciplina(3, 5),
                    new AlunoDisciplina(3, 3),
                    new AlunoDisciplina(4, 6),
                    new AlunoDisciplina(4, 5),
                    new AlunoDisciplina(5, 7),
                    new AlunoDisciplina(5, 4),
                });

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
    }
}