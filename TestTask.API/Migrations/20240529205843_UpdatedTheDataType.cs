using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTheDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionText",
                table: "Candidats",
                newName: "Comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Candidats",
                newName: "DescriptionText");
        }
    }
}
