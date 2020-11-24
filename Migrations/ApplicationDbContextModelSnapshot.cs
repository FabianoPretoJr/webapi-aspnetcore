﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using smartschool.Data;

namespace smartschool.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("smartschool.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Fabiano",
                            Sobrenome = "Preto",
                            Telefone = "12345678"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Gustavo",
                            Sobrenome = "Preto",
                            Telefone = "12345678"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Karine",
                            Sobrenome = "Martins",
                            Telefone = "12345678"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "João",
                            Sobrenome = "Oliveira",
                            Telefone = "12345678"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Isabela",
                            Sobrenome = "Freitas",
                            Telefone = "12345678"
                        });
                });

            modelBuilder.Entity("smartschool.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("alunosDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 2
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 6
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 1
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 8
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 5
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 3
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 6
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 5
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 7
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 4
                        });
                });

            modelBuilder.Entity("smartschool.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Educação Física",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Nome = "GSO",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Engenharia de Software",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Sistemas Operacionais I",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Administração",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Redes",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Gerencia de Projetos",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Eventos",
                            ProfessorId = 1
                        });
                });

            modelBuilder.Entity("smartschool.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Alexandre"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Vania"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Carol"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Aristides"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Demervaldo"
                        });
                });

            modelBuilder.Entity("smartschool.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("smartschool.Models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("smartschool.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("smartschool.Models.Disciplina", b =>
                {
                    b.HasOne("smartschool.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
