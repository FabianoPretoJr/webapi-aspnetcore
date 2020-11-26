using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smartschool.Migrations
{
    public partial class AdicionandoEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "alunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_alunosCursos_alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alunosCursos_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_disciplinas_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_disciplinas_disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_disciplinas_professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_alunosDisciplinas_alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alunosDisciplinas_disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(2797), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(5388), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(5454), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(5461), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(5465), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(5475), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(5479), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 98, DateTimeKind.Local).AddTicks(6664), "Lauro", 0, "Oliveira", null },
                    { 2, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 99, DateTimeKind.Local).AddTicks(9835), "Roberto", 0, "Soares", null },
                    { 3, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 99, DateTimeKind.Local).AddTicks(9889), "Ronaldo", 0, "Marconi", null },
                    { 4, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 99, DateTimeKind.Local).AddTicks(9893), "Rodrigo", 0, "Carvalho", null },
                    { 5, true, null, new DateTime(2020, 11, 25, 19, 43, 29, 99, DateTimeKind.Local).AddTicks(9895), "Alexandre", 0, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "alunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7738), null },
                    { 4, 5, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7757), null },
                    { 2, 5, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7745), null },
                    { 1, 5, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7736), null },
                    { 7, 4, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7775), null },
                    { 6, 4, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7767), null },
                    { 5, 4, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7758), null },
                    { 4, 4, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7755), null },
                    { 1, 4, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7712), null },
                    { 7, 3, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7773), null },
                    { 5, 5, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7760), null },
                    { 6, 3, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7764), null },
                    { 7, 2, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7772), null },
                    { 6, 2, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7763), null },
                    { 3, 2, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7748), null },
                    { 2, 2, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7740), null },
                    { 1, 2, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(6914), null },
                    { 7, 1, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7770), null },
                    { 6, 1, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7761), null },
                    { 4, 1, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7753), null },
                    { 3, 1, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7747), null },
                    { 3, 3, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7750), null },
                    { 7, 5, null, new DateTime(2020, 11, 25, 19, 43, 29, 103, DateTimeKind.Local).AddTicks(7777), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_alunosCursos_CursoId",
                table: "alunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_alunosDisciplinas_DisciplinaId",
                table: "alunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_disciplinas_CursoId",
                table: "disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_disciplinas_PrerequisitoId",
                table: "disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_disciplinas_ProfessorId",
                table: "disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alunosCursos");

            migrationBuilder.DropTable(
                name: "alunosDisciplinas");

            migrationBuilder.DropTable(
                name: "alunos");

            migrationBuilder.DropTable(
                name: "disciplinas");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "professores");
        }
    }
}
