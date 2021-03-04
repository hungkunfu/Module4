using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeMangement.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 10, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    AvatarPath = table.Column<string>(maxLength: 500, nullable: true),
                    Code = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "AvatarPath", "Code", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 18, "avatar11.jpg", "CGH00001", "khoa.nguyen@codegym.vn", "Khoa", "Nguyen" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "AvatarPath", "Code", "Email", "FirstName", "LastName" },
                values: new object[] { 2, 18, "avatar10.jpg", "CGH00002", "hung.tran@codegym.vn", "Hung", "Tran" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "AvatarPath", "Code", "Email", "FirstName", "LastName" },
                values: new object[] { 3, 18, "avatar14.jpg", "CGH00003", "huy.phan@codegym.vn", "Huy", "Phan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
