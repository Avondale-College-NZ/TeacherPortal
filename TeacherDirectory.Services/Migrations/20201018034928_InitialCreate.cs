using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherDirectory.Services.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    //Migration created when I used Initial-Create, created by the Teacher class and consists of all its attributes. 
                    //I had to use the intial create on the TeacherDirectory.Models as it contained all the neccessary information.
                    //Nullable false means they can't be left null
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    TeacherCode = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
