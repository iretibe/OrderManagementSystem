Order Management System
A modular and testable .NET 8 Web API that simulates a real-world Order Management System with support for:

- Order processing and tracking
- Customer segmentation
- Discount rules and analytics
- CQRS with MediatR
- Clean Architecture with DDD principles
- Unit & Integration tests

OrderManagementSystem/
│
├── 📁 src/
│   ├── 📁 OrderManagementSystem.API/            # Couche API (endpoints, startup)
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   ├── Controllers/
│   │
│   │
│   ├── 📁 OrderManagementSystem.Application/    # Couche Application (CQRS, Services, DTOs)
│   │   ├── 📁 Orders/
│   │   │   ├── CreateOrder/
│   │   │   │   ├── CreateOrderCommand.cs
│   │   │   │   ├── CreateOrderHandler.cs
│   │   │   │   └── CreateOrderValidator.cs
│   │   │   ├── UpdateStatus/
│   │   │   ├── GetAnalytics/
│   │   │   └── Discounts/
│   │   │       ├── IDiscountService.cs
│   │   │       └── DiscountService.cs
│   │   └── Common/
│   │       ├── Interfaces/
│   │       ├── Exceptions/
│   │       └── Behaviors/                      # Pipeline (logging, validation, etc.)
│   │
│   ├── 📁 OrderManagementSystem.Domain/         # Couche métier (entités, enums, logiques)
│   │   ├── Entities/
│   │   │   ├── Order.cs
│   │   │   └── Customer.cs
│   │   └── Enums/OrderStatus.cs
│   │
│   ├── 📁 OrderManagementSystem.Infrastructure/ # Accès DB, services externes, EF Core
│   │   ├── Data/
│   │   │   ├── ApplicationDbContext.cs
│   │   │   └── SeedData.cs
│   │   └── Persistence/
│   │       └── Repositories/
│   │
│   └── 📁 OrderManagementSystem.Tests/          # xUnit Tests (par slice)
│       ├── CreateOrderTests.cs
│       ├── DiscountServiceTests.cs
│       └── AnalyticsEndpointTests.cs
│
├── 📄 OrderManagementSystem.sln
└── 📄 README.md

Technologies Used:

.NET 8 Web API
Entity Framework Core
MediatR
Moq
xUnit
FluentValidation (if used)
Swagger / Swashbuckle