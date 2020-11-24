using Microsoft.EntityFrameworkCore.Migrations;

namespace smartschool.Migrations
{
    public partial class AdicionandoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "alunos",
                columns: new[] { "Id", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, "Fabiano", "Preto", "12345678" },
                    { 2, "Gustavo", "Preto", "12345678" },
                    { 3, "Karine", "Martins", "12345678" },
                    { 4, "João", "Oliveira", "12345678" },
                    { 5, "Isabela", "Freitas", "12345678" }
                });

            migrationBuilder.InsertData(
                table: "professores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Alexandre" },
                    { 2, "Vania" },
                    { 3, "Carol" },
                    { 4, "Aristides" },
                    { 5, "Demervaldo" }
                });

            migrationBuilder.InsertData(
                table: "disciplinas",
                columns: new[] { "Id", "Nome", "ProfessorId" },
                values: new object[,]
                {
                    { 1, "Educação Física", 1 },
                    { 8, "Eventos", 1 },
                    { 3, "Engenharia de Software", 2 },
                    { 2, "GSO", 3 },
                    { 6, "Redes", 3 },
                    { 4, "Sistemas Operacionais I", 4 },
                    { 5, "Administração", 5 },
                    { 7, "Gerencia de Projetos", 5 }
                });

            migrationBuilder.InsertData(
                table: "alunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 8 },
                    { 3, 3 },
                    { 1, 2 },
                    { 1, 6 },
                    { 4, 6 },
                    { 5, 4 },
                    { 3, 5 },
                    { 4, 5 },
                    { 5, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "alunosDisciplinas",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "alunos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "disciplinas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "professores",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
