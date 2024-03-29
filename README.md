Scaffold Database from existing Database

dotnet ef dbcontext scaffold "Name=connectionStrings:MySqlConnectionString" Pomelo.EntityFrameworkCore.MySql --context-dir Data --output-dir Models
