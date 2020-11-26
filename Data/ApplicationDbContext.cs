using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using smartschool.Models;

namespace smartschool.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Aluno> alunos { get; set; }
        public DbSet<AlunoCurso> alunosCursos { get; set; }
        public DbSet<AlunoDisciplina> alunosDisciplinas { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<Disciplina> disciplinas { get; set; }
        public DbSet<Professor> professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>().HasKey(sc => new { sc.AlunoId, sc.DisciplinaId});

            modelBuilder.Entity<AlunoCurso>().HasKey(AD => new {AD.AlunoId, AD.CursoId});

            modelBuilder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, 1, "Lauro", "Oliveira"),
                    new Professor(2, 2, "Roberto", "Soares"),
                    new Professor(3, 3, "Ronaldo", "Marconi"),
                    new Professor(4, 4, "Rodrigo", "Carvalho"),
                    new Professor(5, 5, "Alexandre", "Montanha"),
                });

            modelBuilder.Entity<Curso>()
                .HasData(new List<Curso>{
                    new Curso(1, "Tecnologia da Informação"),
                    new Curso(2, "Sistemas de Informação"),
                    new Curso(3, "Ciência da Computação")             
                });
            
            modelBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1, 1),
                    new Disciplina(2, "Matemática", 1, 3),
                    new Disciplina(3, "Física", 2, 3),
                    new Disciplina(4, "Português", 3, 1),
                    new Disciplina(5, "Inglês", 4, 1),
                    new Disciplina(6, "Inglês", 4, 2),
                    new Disciplina(7, "Inglês", 4, 3),
                    new Disciplina(8, "Programação", 5, 1),
                    new Disciplina(9, "Programação", 5, 2),
                    new Disciplina(10, "Programação", 5, 3)
                });
            
            modelBuilder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, 1, "Marta", "Kent", "33225555", DateTime.ParseExact("05/28/2005", "MM/dd/yyyy", null)),
                    new Aluno(2, 2, "Paula", "Isabela", "3354288", DateTime.ParseExact("05/28/2005", "MM/dd/yyyy", null)),
                    new Aluno(3, 3, "Laura", "Antonia", "55668899", DateTime.ParseExact("05/28/2005", "MM/dd/yyyy", null)),
                    new Aluno(4, 4, "Luiza", "Maria", "6565659", DateTime.ParseExact("05/28/2005", "MM/dd/yyyy", null)),
                    new Aluno(5, 5, "Lucas", "Machado", "565685415", DateTime.ParseExact("05/28/2005", "MM/dd/yyyy", null)),
                    new Aluno(6, 6, "Pedro", "Alvares", "456454545", DateTime.ParseExact("05/28/2005", "MM/dd/yyyy", null)),
                    new Aluno(7, 7, "Paulo", "José", "9874512", DateTime.ParseExact("05/28/2005", "MM/dd/yyyy", null))
                });

            modelBuilder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
                });

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
    }
}