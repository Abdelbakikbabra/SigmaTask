The Candidate Management API is a RESTful web service built using ASP.NET Core, designed to manage candidate information for recruitment purposes. The API allows for adding and updating candidate profiles using their email as a unique identifier. If a candidate profile already exists, it will be updated; if not, a new profile will be created.

Features
- Add or Update Candidate: Supports adding new candidates or updating existing ones based on their email.
- Input Validation: Ensures required fields are provided and properly formatted.
- Time Interval for Calls: Captures the best time interval to call candidates if needed.
- Profile Links: Stores URLs for candidates' LinkedIn and GitHub profiles.
- Comments: Allows recruiters to add free-text comments about candidates.
- Asynchronous Operations: All database operations are asynchronous to ensure high performance and scalability.
- Modular Design: Uses a service layer for business logic to promote maintainability and testability.
- Database Agnostic: Designed to support easy migration to different types of databases in the future.

Technology Stack
- Backend: ASP.NET Core Web API
- Database: Entity Framework Core with SQL (Like SQL server)
- Dependency Injection: Built-in ASP.NET Core DI
- Testing: xUnit, Moq, and In-memory database for unit tests

Prerequisites
- .NET 6.0 SDK or later
- SQL server database
- Visual Studio or any other C# compatible IDE (visual code with c# extensions)

Installation
- Clone the repository: git clone https://github.com/abdelbakikbabra/TestTask.git
- Update the connection string in your "appsettings.json"
- runa database migration : dotnet ef database update
  and then run the app
  
Future Improvements
- Enhanced Input Validation: Implement more robust validation for input fields.
- Error Handling: Add global error handling and custom error response models.
- Authentication and Authorization: Secure the API using JWT tokens.
- Integration Tests: Add end-to-end tests to cover full API functionality.
- Detailed Logging: Integrate a logging framework for better monitoring and debugging.
- API Documentation: Use Swagger/OpenAPI for interactive API documentation.
- Performance: Use caching strategies for frequently accessed data to reduce database load.

Assumptions
- Documentation: I used Swagger to generate interactive API documentation to help me provide details about API, including request/response models, endpoints, and example requests.
- Logging: Integrate a logging framework like Serilog or NLog to provide detailed logs for debugging and monitoring.
- Asynchronous Operations: Ensure all database operations are asynchronous to improve performance and scalability.
- Code Quality: I applied code quality tools like Sonar to analyze the codebase for potential issues and improvements.
- Service Layer: The business logic is abstracted into a service layer to adhere to the separation of concerns principle.
- Validation: Basic validation is performed using data annotations in the DTO, and further validation logic is assumed to be added as needed.

Time Spent is 6-7 hours
