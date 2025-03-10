using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

// MEGJEGYZÉS: csak 1 vezetéknév és 1 keresztnév kezelésére alkalmas
namespace CourseController.Migrations
{
    /// <inheritdoc />
    public partial class RefactorName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "TEXT",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(
                "UPDATE Users " +
                "SET Name = TRIM(" +  // TRIM eltávolítja a szóközöket az elejéről és a végéről
                    "COALESCE(FirstName, '') || " +  // Ha a FirstName NULL, üres stringet ad
                    "CASE WHEN FirstName IS NOT NULL AND LastName IS NOT NULL " + // Ha mindkettő nem NULL, szóközt is hozzáadunk
                    "THEN ' ' " +
                    "ELSE '' END || " +  // Ha bármelyik NULL, akkor nem adunk szóközt
                    "COALESCE(LastName, '')" +  // Ha a LastName NULL, üres stringet ad
                ")"
            );

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(
                  "UPDATE Users " +
                  "SET FirstName = CASE " +  // Ha van szóköz a Name-ben, akkor a FirstName a szó első része
                      "WHEN INSTR(Name, ' ') > 0 " +
                      "THEN SUBSTR(Name, 1, INSTR(Name, ' ') - 1) " +  // Első szó = FirstName
                      "ELSE Name " +  // Ha nincs szóköz, akkor az egész Name lesz FirstName
                  "END, " +
                  "LastName = CASE " +  // Ha van szóköz a Name-ben, akkor a LastName a szó második része
                      "WHEN INSTR(Name, ' ') > 0 " +
                      "THEN SUBSTR(Name, INSTR(Name, ' ') + 1) " +  // Második szó = LastName
                      "ELSE NULL " +  // Ha nincs szóköz, akkor a LastName legyen NULL
                  "END " +
                  "WHERE Name IS NOT NULL;"  // Biztosítjuk, hogy csak akkor frissítünk, ha a Name mező nem NULL
              );

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");
        }
    }
}
