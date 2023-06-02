# SimpraApi

## Project Description
SimpraApi is an API project that enables CRUD operations on `Product`, `User` and `Category` entities. This project is also developing regularly. New technologies
will be integrated simultaneously with the bootcamp.

It is built using ASP.NET Core Web API 6.0. This project utilizes various technologies and frameworks, including:

- Entity Framework
- Serilog
- Authorization
- AutoMapper
- In-Memory Caching
- Fluent Validation
- Onion Architecture
- CQRS Pattern
- MSSQL and PostgreSQL
- Bogus

## Installation
To run the SimpraApi project locally, you can choose either of the following options:

1. **Using Git Command Line**:
   - Clone the repository from GitHub using the command: `git clone [repository URL]`
   - Navigate to the project directory: `cd SimpraApi`
   - Build the project: `dotnet build`
   - Run the project: `dotnet run`

2. **Using GitHub**:
   - Visit the project repository on GitHub: [SimpraApi](https://github.com/furkansahin16/simpra-dotnet-bootcamp/tree/main/works/SimpraApi)
   - Click on the **Code** button and select **Download ZIP**
   - Extract the downloaded ZIP file
   - Open the project in your preferred development environment
   - Build and run the project

## Usage
To configure the database type (MSSQL or PostgreSQL), you can modify the connection string in the `appsettings.json` file. Follow the steps below:

1. Open the `appsettings.json` file in your project.
2. Locate the `"ConnectionStrings"` section.
3. Set the `DbType` for either `MsSql` or `PostgreSql`,
4. Set the appropriate connection string for either `MsSql`or `PostgreSql`.

**Sample Connection String Configuration:**

```json
"ConnectionStrings": {
    "DbType": "MsSql",
    "MsSql": "Server=[YourServer]; Database=[YourDbName];Trusted_Connection=True;",
    "PostgreSql": "User ID=[YourUserId];Password=[YourPassword];Server=localhost;Port=[ServerPort];Database=[YourDbName];Integrated Security=true;Pooling=true;"
  }
}
```

### Database Migrations
To install the migration and create the database using Entity Framework, you have two opitons:
(The first migration file for MSSQL is installed on the solution. If you are going to use MSSQL, you can go directly to the 'update database' phase. If you are going to use PostgreSQL, you need to delete the migration file and create new migration.)

1. **Command Line**:
   - Open a command prompt in the project's root directory.
   - Navigate to the project directory: `cd SimpraApi`
   - Create migration: `dotnet ef migrations add [MigrationName] --project "./SimpraApi.Data" -s "./SimpraApi.Service"`
   - Update database: `dotnet ef database update --project "./SimpraApi.Service" --startup-project "./SimpraApi.Service"`

2. **Package Manager Console**:
   - Open the package manager console in Visual Studio.
   - Select the 'SimpraApi.Data' from 'Default project' dropdown.
   - Create migration: `add migration [MigrationName]`
   - Update database: `update database`

### Swagger Integration
The SimpraApi project includes Swagger integration for easy API exploration. After running project locally, you can access the Swagger UI using the following URL:
`https://localhost:{port}/swagger/index.html`
