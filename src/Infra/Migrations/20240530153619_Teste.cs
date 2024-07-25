using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Clientes_CompradorId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_CompradorId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "CompradorId",
                table: "Veiculos");

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ClienteId",
                table: "Compras",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_VeiculoId",
                table: "Compras",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.AddColumn<int>(
                name: "CompradorId",
                table: "Veiculos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_CompradorId",
                table: "Veiculos",
                column: "CompradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Clientes_CompradorId",
                table: "Veiculos",
                column: "CompradorId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
