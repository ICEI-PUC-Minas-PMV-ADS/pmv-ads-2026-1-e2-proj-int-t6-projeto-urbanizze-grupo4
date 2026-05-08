using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Urbanizze.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CIDADAO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIDADAO", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PREFEITURA_CIDADE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PREFEITURA_CIDADE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTAMENTO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_prefeitura_cidade = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTAMENTO", x => x.id);
                    table.ForeignKey(
                        name: "FK_DEPARTAMENTO_PREFEITURA_CIDADE_id_prefeitura_cidade",
                        column: x => x.id_prefeitura_cidade,
                        principalTable: "PREFEITURA_CIDADE",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cidadao = table.Column<int>(type: "int", nullable: false),
                    id_departamento = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIO", x => x.id);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_CIDADAO_id_cidadao",
                        column: x => x.id_cidadao,
                        principalTable: "CIDADAO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_DEPARTAMENTO_id_departamento",
                        column: x => x.id_departamento,
                        principalTable: "DEPARTAMENTO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DENUNCIA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cidadao = table.Column<int>(type: "int", nullable: false),
                    id_departamento = table.Column<int>(type: "int", nullable: false),
                    id_funcionario = table.Column<int>(type: "int", nullable: true),
                    id_status_denuncia = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anonima = table.Column<bool>(type: "bit", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusDenuncia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DENUNCIA", x => x.id);
                    table.ForeignKey(
                        name: "FK_DENUNCIA_CIDADAO_id_cidadao",
                        column: x => x.id_cidadao,
                        principalTable: "CIDADAO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DENUNCIA_DEPARTAMENTO_id_departamento",
                        column: x => x.id_departamento,
                        principalTable: "DEPARTAMENTO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DENUNCIA_FUNCIONARIO_id_funcionario",
                        column: x => x.id_funcionario,
                        principalTable: "FUNCIONARIO",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "MENSAGEM",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_denuncia = table.Column<int>(type: "int", nullable: false),
                    id_cidadao = table.Column<int>(type: "int", nullable: true),
                    id_funcionario = table.Column<int>(type: "int", nullable: true),
                    mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSAGEM", x => x.id);
                    table.ForeignKey(
                        name: "FK_MENSAGEM_CIDADAO_id_cidadao",
                        column: x => x.id_cidadao,
                        principalTable: "CIDADAO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MENSAGEM_DENUNCIA_id_denuncia",
                        column: x => x.id_denuncia,
                        principalTable: "DENUNCIA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MENSAGEM_FUNCIONARIO_id_funcionario",
                        column: x => x.id_funcionario,
                        principalTable: "FUNCIONARIO",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICACAO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cidadao = table.Column<int>(type: "int", nullable: false),
                    id_denuncia = table.Column<int>(type: "int", nullable: true),
                    mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lida = table.Column<bool>(type: "bit", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICACAO", x => x.id);
                    table.ForeignKey(
                        name: "FK_NOTIFICACAO_CIDADAO_id_cidadao",
                        column: x => x.id_cidadao,
                        principalTable: "CIDADAO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTIFICACAO_DENUNCIA_id_denuncia",
                        column: x => x.id_denuncia,
                        principalTable: "DENUNCIA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANEXO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_mensagem = table.Column<int>(type: "int", nullable: false),
                    nome_arquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANEXO", x => x.id);
                    table.ForeignKey(
                        name: "FK_ANEXO_MENSAGEM_id_mensagem",
                        column: x => x.id_mensagem,
                        principalTable: "MENSAGEM",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ANEXO_id_mensagem",
                table: "ANEXO",
                column: "id_mensagem");

            migrationBuilder.CreateIndex(
                name: "IX_DENUNCIA_id_cidadao",
                table: "DENUNCIA",
                column: "id_cidadao");

            migrationBuilder.CreateIndex(
                name: "IX_DENUNCIA_id_departamento",
                table: "DENUNCIA",
                column: "id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_DENUNCIA_id_funcionario",
                table: "DENUNCIA",
                column: "id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTAMENTO_id_prefeitura_cidade",
                table: "DEPARTAMENTO",
                column: "id_prefeitura_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_id_cidadao",
                table: "FUNCIONARIO",
                column: "id_cidadao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_id_departamento",
                table: "FUNCIONARIO",
                column: "id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_MENSAGEM_id_cidadao",
                table: "MENSAGEM",
                column: "id_cidadao");

            migrationBuilder.CreateIndex(
                name: "IX_MENSAGEM_id_denuncia",
                table: "MENSAGEM",
                column: "id_denuncia");

            migrationBuilder.CreateIndex(
                name: "IX_MENSAGEM_id_funcionario",
                table: "MENSAGEM",
                column: "id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACAO_id_cidadao",
                table: "NOTIFICACAO",
                column: "id_cidadao");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACAO_id_denuncia",
                table: "NOTIFICACAO",
                column: "id_denuncia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ANEXO");

            migrationBuilder.DropTable(
                name: "NOTIFICACAO");

            migrationBuilder.DropTable(
                name: "MENSAGEM");

            migrationBuilder.DropTable(
                name: "DENUNCIA");

            migrationBuilder.DropTable(
                name: "FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "CIDADAO");

            migrationBuilder.DropTable(
                name: "DEPARTAMENTO");

            migrationBuilder.DropTable(
                name: "PREFEITURA_CIDADE");
        }
    }
}
