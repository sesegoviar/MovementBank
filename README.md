# Store Clean Architecture
Clean Architecture's implementation in 3 layers (Application Core, Infrastructure and Web API)

To build this project
```
dotnet restore
dotnet build
```

Configure the database settings in src\Bank.WebApi\appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1,1433;Database=Master;User ID=SA;Password=#ecuador123;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

To create the tables in the database, go to src\Bank.WebApi
```
dotnet ef migrations add Initial --project Bank.Infrastructure --startup-project Bank.WebApi
dotnet ef database update
```

To run, go to src\Bank.WebApi
```
dotnet run
```

To test Unit and Integration projects, go to solution folder
```
dotnet test
```
"# CleanNet5SqlServer" 
