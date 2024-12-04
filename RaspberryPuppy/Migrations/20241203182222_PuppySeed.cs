using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaspberryPuppy.Migrations
{
    /// <inheritdoc />
    public partial class PuppySeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Alter the ID column to be auto-increment
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Puppies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            // Insert mock data
            migrationBuilder.InsertData(
                table: "Puppies",
                columns: new[] { "ID", "Name", "Race", "NeedToWalk", "Sounds" },
                values: new object[,]
                {
                    { 1, "Buddy", "Golden Retriever", true, 1 },
                    { 2, "Max", "German Shepherd", true, 1 },
                    { 3, "Charlie", "Bulldog", true, 1 },
                    { 4, "Bella", "Poodle", true, 2 },
                    { 5, "Lucy", "Beagle", true, 2 },
                    { 6, "Daisy", "Rottweiler", true, 1 },
                    { 7, "Luna", "Yorkshire Terrier", true, 2 },
                    { 8, "Cooper", "Boxer", true, 1 },
                    { 9, "Rocky", "Dachshund", true, 2 },
                    { 10, "Lola", "Siberian Husky", true, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the ID column to not be auto-increment
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Puppies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            // Delete the mock data
            migrationBuilder.DeleteData(
                table: "Puppies",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }
    }
}