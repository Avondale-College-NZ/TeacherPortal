using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherDirectory.Services.Migrations
{
    public partial class spGetTeacherByID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Query to get the teacher by ID
            string procedure = @"Create procedure spGetTeacherByID
@ID int
as
Begin
	Select * from Teachers
	where ID = @ID
End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetTeacherByID";
            migrationBuilder.Sql(procedure);
        }
    }
}
