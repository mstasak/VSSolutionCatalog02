# VSSolutionCatalog02

App to maintain a database containing descriptions of the Visual Studio Solutions on your PC.
The database is seeded using a simple directory scan for \*.sln solution files.  Manual edits
add explanations of the projects, ratings, plans for relocation/deletion, etc.  The app is
written in C# using Windows App SDK, Template Studio, MVVM, and Community Toolkits.
PostgreSQL is the back end database, with EF Core providing ORM access and version migrations.

Unfortunately, Windows App SDK doesn't support .NET 8 or 9 yet (not sure why), so this uses
some rather dated component versions targetting .NET 7.

Status: ***early development***. You can clone it and run it, but will immediately run into issues
configuring the PostgreSQL database, schema, and users (not documented, needs refinement too). 
Basic browse and CRUD capabilities are also in work.

Down the road...  Good filter/search capabilities, copy each solution's readme file(s), 
identify valuable techniques and sample code in each solution.