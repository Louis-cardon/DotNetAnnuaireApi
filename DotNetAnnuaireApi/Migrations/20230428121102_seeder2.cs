using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetAnnuaireApi.Migrations
{
    /// <inheritdoc />
    public partial class seeder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var motDePasseHash = BCrypt.Net.BCrypt.HashPassword("password");
            // Insertion des salariés
            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "Nom", "Prenom", "TelephoneFixe", "TelephonePortable", "Email", "MotDePasse", "ServiceId", "SiteId", "RoleId" },
                values: new object[,]
                {
                    { 10, "Durand", "Pierre", "0102030405", "0607080910", "pierre.durand@example.com", motDePasseHash, 2, 2, 2 },
                    {11, "Martin", "Sophie", "0102030405", "0607080910", "sophie.martin@example.com", motDePasseHash, 3, 3, 2 },
                    { 12, "Lefebvre", "Lucas", "0102030405", "0607080910", "lucas.lefebvre@example.com", motDePasseHash, 3, 3, 1 },
                    { 13, "Moreau", "Camille", "0102030405", "0607080910", "camille.moreau@example.com", motDePasseHash, 3, 3, 1 },
                    { 14, "Simon", "Marie", "0102030405", "0607080910", "marie.simon@example.com", motDePasseHash, 1, 2, 2 },
                    { 15, "Leroy", "Thomas", "0102030405", "0607080910", "thomas.leroy@example.com", motDePasseHash, 2, 1, 2 },
                    { 16, "Roux", "Paul", "0102030405", "0607080910", "paul.roux@example.com", motDePasseHash, 2, 2, 1 },
                    { 17, "Petit", "Léa", "0102030405", "0607080910", "lea.petit@example.com", motDePasseHash, 2, 3, 2 },
                    { 18, "Garcia", "Hugo", "0102030405", "0607080910", "hugo.garcia@example.com", motDePasseHash, 3, 2, 1 },
                    { 19, "Lopez", "Clément", "0102030405", "0607080910", "clement.lopez@example.com", motDePasseHash, 3, 2, 1 },
                    { 20, "Girard", "Inès", "0102030405", "0607080910", "ines.girard@example.com", motDePasseHash,  3, 2, 1 },
                    { 21, "Perrin", "Jules", "0102030405", "0607080910", "jules.perrin@example.com", motDePasseHash,  3, 2, 1 },
                    { 22, "Lemaire", "Ambre", "0102030405", "0607080910", "ambre.lemaire@example.com", motDePasseHash,  3, 2, 1 },
                    { 23, "Aubert", "Axel", "0102030405", "0607080910", "axel.aubert@example.com", motDePasseHash,  3, 2, 1 },
                    { 24, "Renard", "Manon", "0102030405", "0607080910", "manon.renard@example.com", motDePasseHash,  3, 2, 1 },
                    { 25, "Fournier", "Maxime", "0102030405", "0607080910", "maxime.fournier@example.com", motDePasseHash,  3, 2, 1 },
                    { 26, "Guillaume", "Noémie", "0102030405", "0607080910", "noemie.guillaume@example.com", motDePasseHash,  3, 2, 1 },
                    { 27, "Gauthier", "Nathan", "0102030405", "0607080910", "nathan.gauthier@example.com", motDePasseHash,  3, 2, 1 },
                    { 28, "Marchand", "Valentine", "0102030405", "0607080910", "valentine.marchand@example.com", motDePasseHash, 3, 2, 1 },
                    { 29, "Dupont", "Jean", "0102030405", "0607080910", "jean.dupont@example.com", motDePasseHash, 1, 1, 1 }

                });
        }
    /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Suppression des salariés
            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValues: new object[] { 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 });
        }
    }

}


