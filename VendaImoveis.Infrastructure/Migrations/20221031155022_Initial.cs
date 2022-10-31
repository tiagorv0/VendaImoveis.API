using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaImoveis.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propriedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    AreaTotal = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false),
                    AreaConstruida = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: true),
                    QuantidadeGaragem = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false),
                    TipoImovelId = table.Column<int>(type: "int", nullable: false),
                    FoiVendida = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propriedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propriedades_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propriedades_PropertyTypes_TipoImovelId",
                        column: x => x.TipoImovelId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Imobiliarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuarioId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CRECI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imobiliarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imobiliarias_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imobiliarias_UserRoles_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Anuncios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ImobiliariaId = table.Column<int>(type: "int", nullable: false),
                    PropriedadeId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anuncios_Imobiliarias_ImobiliariaId",
                        column: x => x.ImobiliariaId,
                        principalTable: "Imobiliarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anuncios_Propriedades_PropriedadeId",
                        column: x => x.PropriedadeId,
                        principalTable: "Propriedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Corretores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    ImobiliariaId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuarioId = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CRECI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corretores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corretores_Imobiliarias_ImobiliariaId",
                        column: x => x.ImobiliariaId,
                        principalTable: "Imobiliarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corretores_UserRoles_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnuncioId = table.Column<int>(type: "int", nullable: false),
                    CorretorId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Anuncios_AnuncioId",
                        column: x => x.AnuncioId,
                        principalTable: "Anuncios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Corretores_CorretorId",
                        column: x => x.CorretorId,
                        principalTable: "Corretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Residencial" },
                    { 2, "Comercial" },
                    { 3, "Industrial" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Imobiliaria" },
                    { 2, "Corretor" },
                    { 3, "Comum" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_ImobiliariaId",
                table: "Anuncios",
                column: "ImobiliariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_PropriedadeId",
                table: "Anuncios",
                column: "PropriedadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Corretores_CPF",
                table: "Corretores",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corretores_CRECI",
                table: "Corretores",
                column: "CRECI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corretores_Email",
                table: "Corretores",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corretores_ImobiliariaId",
                table: "Corretores",
                column: "ImobiliariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Corretores_NomeUsuario",
                table: "Corretores",
                column: "NomeUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corretores_TipoUsuarioId",
                table: "Corretores",
                column: "TipoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Imobiliarias_CNPJ",
                table: "Imobiliarias",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imobiliarias_CRECI",
                table: "Imobiliarias",
                column: "CRECI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imobiliarias_Email",
                table: "Imobiliarias",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imobiliarias_EnderecoId",
                table: "Imobiliarias",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Imobiliarias_NomeUsuario",
                table: "Imobiliarias",
                column: "NomeUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imobiliarias_TipoUsuarioId",
                table: "Imobiliarias",
                column: "TipoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Propriedades_EnderecoId",
                table: "Propriedades",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Propriedades_TipoImovelId",
                table: "Propriedades",
                column: "TipoImovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_AnuncioId",
                table: "Vendas",
                column: "AnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CorretorId",
                table: "Vendas",
                column: "CorretorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Anuncios");

            migrationBuilder.DropTable(
                name: "Corretores");

            migrationBuilder.DropTable(
                name: "Propriedades");

            migrationBuilder.DropTable(
                name: "Imobiliarias");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
