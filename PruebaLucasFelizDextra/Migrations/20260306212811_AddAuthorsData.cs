using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PruebaLucasFelizDextra.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Autor_Id", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { 1, "Dominicano", "Américo Lugo" },
                    { 2, "Mexicano", "Gabriel García Márquez" },
                    { 3, "Venezolano", "Miguel de Cervantes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Autor_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Autor_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Autor_Id",
                keyValue: 3);
        }
    }
}
