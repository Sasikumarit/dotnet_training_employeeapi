# Employee API

## Overview

This is a .NET Core 8 Web API project for managing employees with CRUD operations. It uses CosmosDB for data storage and incorporates various patterns and practices such as CQRS, MediatR, FluentValidation, and the Repository Pattern. AutoMapper is used for mapping between DTOs and domain models, and both unit and integration tests are provided.

## Features

- Create, Read, Update, and Delete employee records.
- Validations using FluentValidation.
- Implements CQRS and MediatR for separation of concerns.
- Repository pattern for data access abstraction.
- AutoMapper for DTO and Model mapping.
- Unit and integration tests included.

## Getting Started

1. Clone the repository.
2. Set up CosmosDB and update `appsettings.json` with your connection details.
3. Run the application using `dotnet run`.

## Running Tests

Unit and integration tests can be run using the following command:
`dotnet test`.

## Explanation of Folders:

### Controllers/: 
- Contains your API controllers, handling the incoming HTTP requests.

### Models/: 
- Contains the data models representing your domain entities (e.g., Employee).

### DTOs/: 
- Data Transfer Objects (DTOs) for transferring data between the API and the client.

### Repositories/: 
- Implements the repository pattern, handling data access to CosmosDB.

### CQRS/:

### Commands/: 
- Contains command classes for creating, updating, and deleting employees.
### Queries/: 
- Contains query classes for reading employee data.
### Handlers/: 
- Contains the handlers for the commands and queries, implementing the business logic.
### Validators/: 
- Contains the FluentValidation classes to validate your DTOs.

### Mappings/: 
- Contains AutoMapper profiles for mapping between models and DTOs.

### Tests/:

### UnitTests/: 
- Contains unit tests for individual components (e.g., handlers, validators).
### IntegrationTests/: 
- Contains integration tests that test the API end-to-end.
### Configuration/: 
- Contains configuration classes, such as the CosmosDB settings.
### Program.cs: 
- The entry point of the application (with Main method and CreateHostBuilder).