using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetAnnuaireApi.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insertion des sites
            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "Ville" },
                values: new object[,]
                {
                    { 1, "Paris" },
                    { 2, "Lyon" },
                    { 3, "Marseille" }
                });

            // Insertion des services
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Service informatique" },
                    { 2, "Service commercial" },
                    { 3, "Service marketing" }
                });

            // Insertion des rôles
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Administrateur" },
                    { 2, "Visiteur" }
                });

            // Insertion des salariés
            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "Nom", "Prenom", "TelephoneFixe", "TelephonePortable", "Email", "ServiceId", "SiteId", "RoleId" },
                values: new object[,]
                {
                    { 1, "Dupont", "Jean", "0102030405", "0607080910", "jean.dupont@example.com", 1, 1, 1 },
                    { 2, "Durand", "Pierre", "0102030405", "0607080910", "pierre.durand@example.com", 2, 2, 2 },
                    { 3, "Martin", "Sophie", "0102030405", "0607080910", "sophie.martin@example.com", 3, 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Suppression des salariés
            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            // Suppression des services
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            // Suppression des sites
            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            // Suppression des rôles
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2 });
        }
    }
}
