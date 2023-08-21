# Web API

Todo RESTful Web API.

## Structure

The project structure follows Clean Architecture Principles and is inspired by:
* [CleanArchitecture by jasontaylordev](https://github.com/jasontaylordev/CleanArchitecture)
* [CleanArchitecture by ardalis](https://github.com/ardalis/CleanArchitecture)
* [fullstackhero's .NET Web API Boilerplate](https://github.com/fullstackhero/dotnet-webapi-boilerplate)
* [The Software Architecture Chronicles by hgraca](https://herbertograca.com/2017/07/03/the-software-architecture-chronicles/)

## Technologies

* [ASP.NET Core 7](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core 7](https://docs.microsoft.com/en-us/ef/core/)
* [Mediator](https://github.com/martinothamar/Mediator)
* [Mapperly](https://github.com/riok/mapperly)

## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```sh
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

## Code Styles & Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

## Test (WIP)

The solution contains unit, integration, and functional tests.

To run the tests:
```sh
dotnet test
```