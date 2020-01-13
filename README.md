# Interview Task SW Development(m/f)
## Verivox.Solution

The solution comprises of four projects. two of them are unit test projects and the others are implementation.
at `Verivox.Api.Core` core of business has been developed, at `Verivox.Api` the core business is going to
be hosted as ASP.NET Core Web Api.

The role of `Verivox.Api.Core.UnitTest` unit test project is to test core business. but `Verivox.Api.UnitTest` 
is to test hosted service. This test project tries to host the API in a TestServer send HTTP request to that hosted 
API and checks returned results. The `Verivox.Api` also has Swagger for testing through browser.

**The technologies has been used with this solution**
> - ASP.NET Web API Core 3.0

> - xUnit for Unit Testing

> - .Net Standard for Class Libraries.

> - Basic .Net Core Log.

> - Swagger 5.0.0-rc5.

> - Basic .Net Core Debendency Injection Container.
