﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitireContoareApa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarif",
                columns: table => new
                {
                    TarifId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PretPeMetruCub = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInceput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSfarsit = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarif", x => x.TarifId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Contor",
                columns: table => new
                {
                    ContorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumarSerie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValoareActuala = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contor", x => x.ContorId);
                    table.ForeignKey(
                        name: "FK_Contor_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEmitere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContorId = table.Column<int>(type: "int", nullable: false),
                    PlataId = table.Column<int>(type: "int", nullable: true),
                    TarifId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_Factura_Contor_ContorId",
                        column: x => x.ContorId,
                        principalTable: "Contor",
                        principalColumn: "ContorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_Tarif_TarifId",
                        column: x => x.TarifId,
                        principalTable: "Tarif",
                        principalColumn: "TarifId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plata",
                columns: table => new
                {
                    PlataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPlatii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SumaPlatita = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModalitateDePlata = table.Column<int>(type: "int", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plata", x => x.PlataId);
                    table.ForeignKey(
                        name: "FK_Plata_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contor_UserId",
                table: "Contor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ContorId",
                table: "Factura",
                column: "ContorId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_PlataId",
                table: "Factura",
                column: "PlataId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_TarifId",
                table: "Factura",
                column: "TarifId");

            migrationBuilder.CreateIndex(
                name: "IX_Plata_FacturaId",
                table: "Plata",
                column: "FacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Plata_PlataId",
                table: "Factura",
                column: "PlataId",
                principalTable: "Plata",
                principalColumn: "PlataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contor_User_UserId",
                table: "Contor");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Contor_ContorId",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Plata_PlataId",
                table: "Factura");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Contor");

            migrationBuilder.DropTable(
                name: "Plata");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Tarif");
        }
    }
}