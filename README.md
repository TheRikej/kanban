Prototype of a shared task managment for a multi-user enviroment.

Project is written in C#, UI was made using Winforms.

You can build and start the project by running:

```
cd Kanban
dotnet build
dotnet run
```

This program uses WinForms, therfore requires Windows to run.
Before running this program, you have to have a conntection to a local MSSQL server (server=(localdb)\MSSQLLocalDB).
Alternatively, you can change DbPath string in Kanban/Database/DbAccess.cs to use your DB server.

Initial Admin email and password are both set to an empty string. This can be changed either in application,
by editing seeding in function RefreshDb in Kanban/Database/DbAccess.cs
