# TeacherPortal

Open the code with visual studio and clone the project. 
Click View > Other Windows > Packet manager Console
Type "Add-Migration" InitialCreate and make sure TeacherDirectory.Models is selected for the location, install any required packages on your computer.

On the Sql Server use this to create the neccessary stored Procedure called spInsertTeacher:

Create Proc spInsertTeacher

@FirstName nvarchar(100),

@Email nvarchar(100),

@PhotoPath nvarchar(100),

@Dept int

AS

BEGIN

INSERT INTO Teachers

(FirstName, Email, PhotoPath, Department)

VALUES (@FirstName, @Email, @PhotoPath, @Dept)

END

and run the query and save it.

You can then begin Debugging and start the application.

