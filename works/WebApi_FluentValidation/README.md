# Asp.Net Web Api - Fluent Validation

## Project Description
This is an API project that enables CRUD operations on `Student` entity. It is built using ASP.NET Core Web API 6.0. This project utilizes various technologies and frameworks, including:

- Fluent Validation

This project includes custom validation with action attributes. It gets errors from model state and return custom response class with validation errors. It also includes an action filter that check request contains `id` argument, and check if any entity found.

## Installation
To run the SimpraApi project locally, you can choose either of the following options:

1. **Using Git Command Line**:
   - Clone the repository from GitHub using the command: `git clone [repository URL]`
   - Navigate to the project directory: `cd SimpraApi`
   - Build the project: `dotnet build`
   - Run the project: `dotnet run`

2. **Using GitHub**:
   - Visit the project repository on GitHub: [WebApi-FluentValdiation](https://github.com/furkansahin16/simpra-dotnet-bootcamp/tree/main/works/WebApi_FluentValidation)
   - Click on the **Code** button and select **Download ZIP**
   - Extract the downloaded ZIP file
   - Open the project in your preferred development environment
   - Build and run the project

### Swagger Integration
The SimpraApi project includes Swagger integration for easy API exploration. After running project locally, you can access the Swagger UI using the following URL:
`https://localhost:{port}/swagger/index.html`
