using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitireContoareApa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Tarif_TarifId",
                table: "Factura");

            migrationBuilder.AlterColumn<int>(
                name: "TarifId",
                table: "Factura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Tarif_TarifId",
                table: "Factura",
                column: "TarifId",
                principalTable: "Tarif",
                principalColumn: "TarifId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Tarif_TarifId",
                table: "Factura");

            migrationBuilder.AlterColumn<int>(
                name: "TarifId",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Tarif_TarifId",
                table: "Factura",
                column: "TarifId",
                principalTable: "Tarif",
                principalColumn: "TarifId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
