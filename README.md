# ec-dotnet
ASP.NET Core Web API Project

---
### 📂 Folder Structure
```
src/
 ├── Application/
 │    ├── Commands/
 │    │    ├── CreateOrder/
 │    │    │    ├── CreateOrderCommand.cs
 │    │    │    ├── CreateOrderHandler.cs
 │    │    │    └── CreateOrderValidator.cs
 │    │    └── UpdateOrder/
 │    │         ├── UpdateOrderCommand.cs
 │    │         ├── UpdateOrderHandler.cs
 │    │         └── UpdateOrderValidator.cs
 │    │
 │    ├── Queries/
 │    │    ├── GetOrderById/
 │    │    │    ├── GetOrderByIdQuery.cs
 │    │    │    ├── GetOrderByIdHandler.cs
 │    │    │    └── GetOrderByIdDto.cs
 │    │    └── GetOrdersList/
 │    │         ├── GetOrdersListQuery.cs
 │    │         ├── GetOrdersListHandler.cs
 │    │         └── GetOrdersListDto.cs
 │    │
 │    ├── Interfaces/
 │    │    ├── ICommand.cs
 │    │    ├── ICommandHandler.cs
 │    │    ├── IQuery.cs
 │    │    └── IQueryHandler.cs
 │    │
 │    └── Common/
 │         ├── Exceptions/
 │         ├── Behaviors/   (e.g., logging, validation pipeline)
 │         └── Mapping/
 │
 ├── Domain/
 │    ├── Entities/
 │    │    └── Order.cs
 │    ├── ValueObjects/
 │    └── Events/
 │
 ├── Infrastructure/
 │    ├── Persistence/
 │    │    ├── AppDbContext.cs
 │    │    └── Configurations/
 │    ├── Repositories/
 │    └── Services/
 │
 ├── API/
 │    ├── Controllers/
 │    │    ├── OrdersController.cs
 │    └── DTOs/
 │
 └── Tests/
      ├── UnitTests/
      └── IntegrationTests/
```