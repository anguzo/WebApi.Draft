## Presentation Layer

The presentation layer serves as the application's primary access point, offering a user-friendly interface to the underlying functionalities.

## Minimal API

The RESTful API, complemented by the SwaggerUI, encapsulates and showcases the application's features and capabilities.

This API is structured around the cutting-edge [Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-7.0) design, ensuring an efficient and streamlined framework.

To ensure clarity and reduce complexity:
- Intricate extension methods or reflection-based techniques are avoided for endpoint registration.
- A direct approach is employed, with endpoints hand-registered in `Program.cs` as illustrated below:
```csharp
app.Map<Entity/UseCase>Endpoints();
```