Order Management System
A modular and testable .NET 8 Web API that simulates a real-world Order Management System with support for:

- Order processing and tracking
- Customer segmentation
- Discount rules and analytics
- CQRS with MediatR
- Clean Architecture with DDD principles
- Unit & Integration tests

OrderManagementSystem/
└── src/
    ├── OrderManagementSystem.API/
    │   ├── Controllers/
    │   │   ├── CustomersController.cs
    │   │   └── OrdersController.cs
    │   ├── appsettings.json
    │   └── Program.cs
    │
    ├── OrderManagementSystem.Application/
    │   ├── Commands/
    │   │   ├── ApplyDiscountCommand.cs
    │   │   ├── CreateCustomerCommand.cs
    │   │   ├── CreateOrderCommand.cs
    │   │   ├── DeleteCustomerCommand.cs
    │   │   ├── UpdateCustomerCommand.cs
    │   │   ├── UpdateOrderCommand.cs
    │   │   └── UpdateOrderStatusCommand.cs
    │   ├── Handlers/
    │   │   ├── ApplyDiscountCommandHandler.cs
    │   │   ├── CreateCustomerCommandHandler.cs
    │   │   ├── CreateOrderCommandHandler.cs
    │   │   ├── DeleteCustomerCommandHandler.cs
    │   │   ├── UpdateCustomerCommandHandler.cs
    │   │   ├── UpdateOrderCommandHandler.cs
    │   │   └── UpdateOrderStatusCommandHandler.cs
    │   ├── Queries/
    │   │   ├── GetAllCustomersQuery.cs
    │   │   ├── GetCustomerByIdQuery.cs
    │   │   ├── GetOrderAnalyticsQuery.cs
    │   │   └── GetOrderByIdQuery.cs
    │   ├── Handlers/
    │   │   ├── GetAllCustomersQueryHandler.cs
    │   │   ├── GetCustomerByIdQueryHandler.cs
    │   │   ├── GetOrderAnalyticsQueryHandler.cs
    │   │   └── GetOrderByIdQueryHandler.cs
    │   └── Exceptions/
    │       ├── AppException.cs
    │       ├── CustomerNotFoundException.cs
    │       └── OrderNotFoundException.cs
    │
    ├── OrderManagementSystem.Domain/
    │   ├── DTOs/
    │   │   └── OrderAnalyticsDto.cs
    │   ├── Entities/
    │   │   ├── BaseEntity.cs
    │   │   ├── Customer.cs
    │   │   ├── Order.cs
    │   │   └── OrderItem.cs
    │   ├── Enums/
    │   │   └── OrderStatus.cs
    │   └── Repositories/
    │       ├── ICustomerRepository.cs
    │       ├── IDiscountRepository.cs
    │       ├── IOrderAnalyticsRepository.cs
    │       └── IOrderRepository.cs
    │
    ├── OrderManagementSystem.Infrastructure/
    │   ├── Configurations/
    │   │   ├── CustomerConfiguration.cs
    │   │   ├── OrderConfiguration.cs
    │   │   └── OrderItemConfiguration.cs
    │   ├── Data/
    │   │   ├── OrderDbContext.cs
    │   │   └── OrderDbContextFactory.cs
    │   ├── Migrations/
    │   │   └── ... (auto-generated)
    │   └── Repositories/
    │       ├── CustomerRepository.cs
    │       ├── DiscountRepository.cs
    │       ├── OrderAnalyticsRepository.cs
    │       └── OrderRepository.cs
    │
    └── OrderManagementSystem.Tests/
        ├── AnalyticsEndpointTests.cs
        ├── ApplyDiscountCommandHandlerTests.cs
        ├── CreateCustomerCommandHandlerTests.cs
        ├── CreateOrderCommandHandlerTests.cs
        ├── DeleteCustomerCommandHandlerTests.cs
        ├── GetAllCustomersQueryHandlerTests.cs
        ├── GetCustomerByIdQueryHandlerTests.cs
        ├── GetOrderAnalyticsQueryHandlerTests.cs
        ├── UpdateCustomerCommandHandlerTests.cs
        └── UpdateOrderStatusCommandHandlerTests.cs


*Technologies Used:*
- .NET 8 Web API
- Entity Framework Core
- MediatR
- Moq
- xUnit
- FluentValidation (if used)
- Swagger / Swashbuckle


* Run the following queries to get the database created after changing the connection string to your database:
* Navigate to the Infrastructure project on a command prompt and type:
 - dotnet ef migrations add OrderMigration
 - dotnet ef database update