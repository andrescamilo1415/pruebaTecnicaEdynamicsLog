using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pruebaTecnicaEdynamicsLog.Migrations.Productos
{
    /// <inheritdoc />
    public partial class AddDescripcionAProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Productos");
        }
    }
}
