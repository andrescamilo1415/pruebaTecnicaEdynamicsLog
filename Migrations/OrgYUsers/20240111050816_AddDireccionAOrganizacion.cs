using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pruebaTecnicaEdynamicsLog.Migrations.OrgYUsers
{
    /// <inheritdoc />
    public partial class AddDireccionAOrganizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Organizaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Organizaciones");
        }
    }
}
