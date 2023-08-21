## WPF client example

The provided WPF client example showcases implementation approaches that are recommended to be applied during development of WPF applications utilizing the Todo RESTful Web API:
* The code is split into two project: Logic and UI. Logic utilizes `net7.0` target framework while UI utilizes `net7.0-windows`. This enables for the application to be more maintainable, scalable and testable.

    > If using .NET Framework, then `netstandard2.0` and `net48` must be used respectively.
* API client is generated using Visual Studio `Connected Services` feature which is linked to the API Swagger document.
* API client capabilites are encapsulated into `Services`.
* API client response types are wrapped into `ViewModels` objects rather than used directly to enable WPF data binding features.
* Dependency injection resolution for service provider is defined in Logic which is then utilized in the UI `App.xaml.cs`.
* `ViewModelLocator` is injected into `App.xaml` as resource, this provies proper Intellisense and avoids using UI code-behind.

    > This approach is a subject for a discussion. A lot of developers utilize ASP.NET Core `IHost` initialization rather than straight forward approach demonstrated in `App.xaml.cs`. 
    > However the benefits of `ViewModelLocator` injection as a resource are quite obvious contrary to `IHost` approach.
* `App.xaml.cs` `OnStartup` method is utilized as application [Composition Root](https://blog.ploeh.dk/2011/07/28/CompositionRoot/).