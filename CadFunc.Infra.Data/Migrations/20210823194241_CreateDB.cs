using Microsoft.EntityFrameworkCore.Migrations;

namespace CadFunc.Infra.Data.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Badge = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Badge", "Email", "LastName", "Name", "Password", "Phone" },
                values: new object[] { 1, 999000, "email1@zup.com.br", "Employee Last Name", "Employee Name 1", "V02zy9YLAaJxk3au/LqxGw==", "47999998888" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Badge", "Email", "LastName", "Name", "Password", "Phone" },
                values: new object[] { 2, 888000, "email2@zup.com.br", "Employee Last Name", "Employee Name 2", "V02zy9YLAaJxk3au/LqxGw==", "47977778888" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Badge", "Email", "LastName", "Name", "Password", "Phone" },
                values: new object[] { 3, 777000, "email3@zup.com.br", "Employee Last Name", "Employee Name 3", "V02zy9YLAaJxk3au/LqxGw==", "47966668888" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
