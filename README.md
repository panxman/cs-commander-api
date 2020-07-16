# Commander API - A C# Rest API project

Video made using the youtube guide from **Les Jackson**: https://www.youtube.com/watch?v=fmvcAzHpsk8

### Note
In the guide, he is using Microsoft SQL Server, but I am using MongoDB, so some files are different (and probably some are unnecessary).

### Run
Provided you have .NET Core installed, navigate to the root of the project and run:
- **dotnet run**

This should build and run the server. You need to have a running MongoDB, with the details provided inside appsettings.json (or you can edit that).

### Routes
- GET: /api/commands -- This will return all available commands
- GET: /api/commands/{id} -- This will return the command with given ID (if it exists)
- POST: /api/commands/ -- This will create a new command. It needs: { HowTo, Line, Platform } all strings
- PUT: /api/commands/{id} -- This will update the command with the given ID (if it exists)
- PATCH: /api/commands/{id} -- This will partially update a command ( *replace* operation )
- DELETE: /api/commands/{id} -- This will delete a command
