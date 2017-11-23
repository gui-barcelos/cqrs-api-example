# **Projects**
## API 
### Handle requests/responses of the API with the correspondent Http codes.
 - Call Application layer to handle Request/Response informations
- Receives and reponds DTOs (Data Transfer Objects) to clients
- Using OWIN as interface between API and IIS
- Using Swagger library for documentation of the API (UI accessible through http://localhost:58123/swagger/)
- Using compression for better performance

## Application
### Handle communication between API an Domain layer, orchestrate bus calls.
- Using AutoMapper for handling mappings between DTOs and Domain classes.
- Call mediator with Commands/Queries.
- Handle errors of Command/Queries.

## Domain 
### Contain all domain/business logic.
- Contain Models.
- Contains Commands, Queries and their Handlers (Using MediatR library).
- Contain Domain Validations (Using FluentValidator library).
- Call Data layer to retrieve/persist informations.

## Data
### Handle Database objects and manipulate data. e.g. Mappings / Repositories / Context.
- Using Entity Framework as ORM for data access.
- Using Code First approach.
- Automatically creates Database and seed data in the first execution.
- Using AsNoTracking for better performance on retrieving data.

## CrossCutting.Common
### Handle common objects used in all projects.
- Currently contains only Log manager (Using log4net library).

## CrossCutting.IoC
### Project that handles Dependency Injection of the application.
- Using Simple Injector library.

## IntegrationTest
### Project that handles integration tests of the API.
- Using Microsoft.Owin.Testing library.

## UnitTest
### Project that handles unit tests of the application.

# Overall Arquiteture and Patterns used
- Domain Driven Design: Layers and Domain Model patterns applied.
- CQRS (Command Query Responsability Segregation) through MediatR library.
- Repository Pattern: Data layer.
- Unit Of Work.
- Decorator Pattern: Injecting Domain Validators via Decorator on Command Handlers.
- Dependendy Injection Pattern.

# Main libraries used
- AutoMapper: Handle mappings.
- EntityFramework: Microsoft ORM.
- FluentValidation: Handle validation through a fluent interface and lambda expressions.
- MediatR: In-process messaging.
- OWIN: Decouple web server and web application.
- SimpleInjector: Depedency Injection.
- log4net: Logging.
- Swashbuckle: Swagger implementation for .NET, documentation for API.