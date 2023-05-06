# Clean Architecture Template

This solution provides a starting point for creating your application using Clean Architecture with .NET.

## Getting Started

This solution is configured with the following projects:
- MediatR for CQRS
- Serilog for structured logging
- Tailwind CSS for styling
- Auth0 for authentication and authorization

#### Auth0 References
- Blazor - https://auth0.com/blog/what-is-blazor-tutorial-on-building-webapp-with-authentication/
- Web API - https://auth0.com/docs/quickstart/backend/aspnet-core-webapi/01-authorization

### Tailwind CSS
The solution is configured to use Tailwind CSS.  To get started, run the following command in the root directory of the solution:
```batch
tailwind-watch.bat
```
This command will start the tailwind cli and watch for changes to Blazor pages/components as well as the tailwind.config.js file.