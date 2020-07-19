using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace estagio_brg.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cargo = table.Column<string>(nullable: true),
                    Departamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trilhas",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(nullable: false),
                    HabilidadeId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Prazo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhas", x => new { x.ColaboradorId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_Trilhas_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trilhas_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Cargo", "Departamento" },
                values: new object[] { 1, "Açougueiro", "Operacional" });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Cargo", "Departamento" },
                values: new object[] { 2, "Administrador", "Recursos Humanos" });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Cargo", "Departamento" },
                values: new object[] { 3, "Analista Administrativo", "Recursos Humanos" });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Cargo", "Departamento" },
                values: new object[] { 4, "Almoxarife", "Empenho" });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Cargo", "Departamento" },
                values: new object[] { 5, "Administrador de Sistemas", "Tributário" });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Cargo", "Departamento" },
                values: new object[] { 6, "Analista de Documentaçãos", "Tributário" });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Cargo", "Departamento" },
                values: new object[] { 7, "Ajudante Geral", "Geral" });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 15, "Criatividade", 2 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 14, "Confiança", 2 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 13, "Liderança", 2 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 12, "Resolução de conflitos", 2 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 11, "Resiliência", 2 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 10, "Proatividade", 2 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 9, "Persuasão", 2 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 5, "Domínio de Exel", 1 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 7, "Inglês", 1 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 6, "Domínio de Contabilidade", 1 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 16, "Comunicação", 2 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 4, "Domínio de C#", 1 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 3, "Programação", 1 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 2, "Mecânica de Motores", 1 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 1, "Gestão de Projetos", 1 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 8, "Comunicação Interpessoal", 2 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Nome", "Tipo" },
                values: new object[] { 17, "Organização", 2 });

            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "ColaboradorId", "HabilidadeId", "Id", "Prazo" },
                values: new object[] { 7, 2, 7, new DateTime(2020, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "ColaboradorId", "HabilidadeId", "Id", "Prazo" },
                values: new object[] { 5, 3, 4, new DateTime(2020, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "ColaboradorId", "HabilidadeId", "Id", "Prazo" },
                values: new object[] { 5, 7, 5, new DateTime(2020, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "ColaboradorId", "HabilidadeId", "Id", "Prazo" },
                values: new object[] { 1, 8, 1, new DateTime(2020, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "ColaboradorId", "HabilidadeId", "Id", "Prazo" },
                values: new object[] { 1, 10, 2, new DateTime(2020, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "ColaboradorId", "HabilidadeId", "Id", "Prazo" },
                values: new object[] { 5, 10, 6, new DateTime(2020, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "ColaboradorId", "HabilidadeId", "Id", "Prazo" },
                values: new object[] { 7, 12, 8, new DateTime(2020, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "ColaboradorId", "HabilidadeId", "Id", "Prazo" },
                values: new object[] { 7, 15, 9, new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "ColaboradorId", "HabilidadeId", "Id", "Prazo" },
                values: new object[] { 1, 17, 3, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Trilhas_HabilidadeId",
                table: "Trilhas",
                column: "HabilidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trilhas");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Habilidades");
        }
    }
}
