using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notepad.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Notes",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Notes",
                newName: "Password");
        }
    }
}
