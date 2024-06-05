CREATE MIGRATION - dotnet ef migrations add <MIGRATION_NAME_> --project CqrsDemo.Infrastructure -s CqrsDemo.API -c AppDbContext --verbose

REMOVE MIGRATION - dotnet ef migrations remove

UPDATE MIGRATION IN DB - dotnet ef database update <MIGRATION_NAME> --project CqrsDemo.Infrastructure -s CqrsDemo.API -c AppDbContext --verbose
