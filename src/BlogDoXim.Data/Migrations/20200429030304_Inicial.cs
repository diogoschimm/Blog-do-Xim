using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDoXim.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Login = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Github = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Artigo",
                columns: table => new
                {
                    ArtigoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(500)", nullable: false),
                    SubTitulo = table.Column<string>(type: "varchar(500)", nullable: false),
                    Resumo = table.Column<string>(type: "varchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "varchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GithubUrl = table.Column<string>(type: "varchar(1000)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_artigo", x => x.ArtigoId);
                    table.ForeignKey(
                        name: "fk_artigo_categoria",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId");
                    table.ForeignKey(
                        name: "fk_artigo_usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "AcessoArtigo",
                columns: table => new
                {
                    AcessoArtigoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataAcesso = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ArtigoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_acessoArtigo", x => x.AcessoArtigoId);
                    table.ForeignKey(
                        name: "fk_acessoArtigo_artigo",
                        column: x => x.ArtigoId,
                        principalTable: "Artigo",
                        principalColumn: "ArtigoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcessoArtigo_ArtigoId",
                table: "AcessoArtigo",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Artigo_CategoriaId",
                table: "Artigo",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Artigo_UsuarioId",
                table: "Artigo",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessoArtigo");

            migrationBuilder.DropTable(
                name: "Artigo");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
